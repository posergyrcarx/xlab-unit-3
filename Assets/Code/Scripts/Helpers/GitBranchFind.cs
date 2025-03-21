using System.Diagnostics;

namespace Code.Scripts.Helpers
{
    public static class GitBranchFind
    {
#if UNITY_EDITOR_WIN
        private const string GitExecutable = @"C:\Program Files\Git\bin\git.exe";
#endif

#if UNITY_EDITOR_OSX
        private const string GitExecutable = "/usr/bin/git";
#endif

#if UNITY_EDITOR
        private const int MaxWaitTime = 1000;

        public static (string, string) GetBranchName(string aRepositoryPath)
        {
            var prc = new Process();
            prc.StartInfo.FileName = GitExecutable;
            
            prc.StartInfo.Arguments = "-C \"" + aRepositoryPath + "\" branch --show-current";
            
            prc.StartInfo.RedirectStandardOutput = true;
            prc.StartInfo.RedirectStandardError = true;
            prc.StartInfo.RedirectStandardInput = true;
            prc.StartInfo.UseShellExecute = false;
            
            prc.Start();
            prc.WaitForExit(MaxWaitTime);

            var output = prc.StandardOutput.ReadToEnd().Trim();
            var error = prc.StandardError.ReadToEnd().Trim();
            
            return (output, error);
        }
#endif
    }
}