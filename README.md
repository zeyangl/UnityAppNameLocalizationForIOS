App name localization for Unity iOS apps.

The plugin works by copying user defined locale folders to the exported xcode project, and modify the project file accordingly.

The plugin uses the xcodeapi library from Unity's official repository, and integrated a long pending pull request, with some changes.

An example is provided. To integrate to your project, just copy the folder 'Assets/NativeLocale', 
and invoke NativeLocale.AddLocalizeNativeStringsIOS in your post process script.

Reference: 
* https://bitbucket.org/Unity-Technologies/xcodeapi
* https://bitbucket.org/Unity-Technologies/xcodeapi/pull-requests/13/creation-of-variantgroup-and/diff
