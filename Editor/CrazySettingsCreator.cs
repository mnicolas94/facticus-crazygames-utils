using System.IO;
using CrazyGames;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;
using PackageInfo = UnityEditor.PackageManager.PackageInfo;

namespace CrazyGamesUtils.Editor
{
    [InitializeOnLoad]
    public class CrazySettingsCreator : IPackageManagerExtension
    {
        static CrazySettingsCreator()
        {
            PackageManagerExtensions.RegisterExtension(new CrazySettingsCreator());
        }

        public VisualElement CreateExtensionUI()
        {
            return null;
        }

        public void OnPackageSelectionChange(PackageInfo packageInfo)
        {
        }

        public void OnPackageAddedOrUpdated(PackageInfo packageInfo)
        {
            if (UpdatedSelf(packageInfo))
            {
                EnsureSettingsExist();
            }
        }

        public void OnPackageRemoved(PackageInfo packageInfo)
        {
        }

        private bool UpdatedSelf(PackageInfo packageInfo)
        {
            return packageInfo.name == "com.facticus.crazygames-utils";
        }

        private void EnsureSettingsExist()
        {
            var crazySettings = Resources.Load<CrazySettings>(CrazySDK.SettingsResourceName);
            if (crazySettings == null)
            {
                var settings = ScriptableObject.CreateInstance<CrazySettings>();
                var path = Path.Combine($"Assets/Resources/{CrazySDK.SettingsResourceName}.asset");
                AssetDatabase.CreateAsset(settings, path);
                AssetDatabase.SaveAssets();
            }
        }
    }
}