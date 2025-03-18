using System.IO;
using TMPro;
using UnityEngine;

namespace Code.Scripts.Helpers
{
    public class GitBranchReveal: MonoBehaviour
    {      
        [SerializeField] private TextMeshProUGUI developerGameInfo;
        [SerializeField] private TextMeshProUGUI interfaceVersion;
        [SerializeField] private bool printApplicationInfo;
        [SerializeField] private bool showInfoInScene;
            
        private void Awake()
        {
#if UNITY_EDITOR
            if (showInfoInScene)
            {
                ShowRepositoryBranchName();
            }

            if (printApplicationInfo)
            {
                DebugApplicationVersion();
            }
#endif
            ShowVersion();
        }

#if UNITY_EDITOR
        private void ShowRepositoryBranchName()
        {
            var pathToFolder = Path.GetDirectoryName(Application.dataPath);
            
            var branchNameOutput = GitBranchFind.GetBranchName(pathToFolder).Item1;
            var branchNameError = GitBranchFind.GetBranchName(pathToFolder).Item2;

            developerGameInfo.text = branchNameOutput != "" ? 
                $"Git branch: {branchNameOutput} Version: {Application.version}" 
                : $"{branchNameError} Version: {Application.version}";
        }
        private void DebugApplicationVersion()
        {
            Debug.Log($"Application version: {Application.version}");
        }
#endif

        private void ShowVersion()
        {
            interfaceVersion.text = $"v. {Application.version}";
        }
    }
}