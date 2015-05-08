using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.ComponentModel;
using System.Security;

using Hatfield.EnviroData.DataAcquisition;

namespace Hatfield.EnviroData.DataAcquisition.FileSystems
{
    public class NetworkFileSystem : IFileSystem
    {
        private string _filePath;
        NetworkCredential _credentials;

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        public NetworkFileSystem(string filePath)
        {
            _filePath = filePath;
            _credentials = null;
        }

        public NetworkFileSystem(string filePath, string username, string password, string domain)
        {
            _filePath = filePath;
            _credentials = new NetworkCredential(username, password, domain);
        }

        public DataFromFileSystem FetchData()
        {
            string fileName;
            FileStream fileStream;

            // If user credentials are provided, impersonate the given user
            if (_credentials != null)
            {
                SafeTokenHandle safeTokenHandle;
                string username = _credentials.UserName;
                string password = _credentials.Password;
                string domain = _credentials.Domain;

                if (LogonUser(username, domain, password, 2, 0, out safeTokenHandle) == true)
                {
                    using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                    {
                        using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                        {
                            fileName = Path.GetFileName(_filePath);
                            fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
                        }
                    }
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
            else
            {
                fileName = Path.GetFileName(_filePath);
                fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
            }

            return new DataFromFileSystem(fileName, fileStream);
        }
    }

    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle()
            : base(true)
        {
        }

        [DllImport("kernel32.dll")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr handle);

        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }
    }
}
