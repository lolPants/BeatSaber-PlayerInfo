# Beat Saber Player Info
*Plugin Library to handle retrieving player info easily.*  
**Supports both Steam and Oculus with one `.dll`!**

## Usage
Firstly, reference the `.dll` in your own plugin. Then import the plugin namespace using the code below.

```csharp
using PlayerInfoPlugin;
```

## Info Manager
To get player info, you will need to use the Info Manager.

```csharp
PlayerInfo.Manager
```

The plugin automatically detects whether the user is running the Steam or Oculus Home version of the game and sets the appropriate manager at runtime.

### Fields
The info manager interface has 4 public fields you can read from.

| Name | Type | Description |
| ---- | ---- | ----------- |
| `Platform` | `string` | Can be one of `Default`, `Steam` or `Oculus`. Default is used when the platform cannot be detected. This should never happen except for before the plugin has fully loaded. |
| `Username` | `string` | Player Username. |
| `UserID` | `ulong` | Player ID. Either a SteamID64 or Oculus ID. |
| `Proof` | `string` | Long server-generated string indicating the user is who they say they are. Defaults to `null` |

### Methods and Events
#### `void LoadPlayerInfo()`
Refreshes current info. Called by the plugin on startup but can be manually re-loaded by calling this method again.

Fires the `Action<string, ulong> PlayerInfoLoaded` event with arguments `Username` and `UserID` respectively.

#### `void RequestPlayerProof()`
Validates the user is who they say they are with a serverside check.
Sets `Proof` back to `null` before validating.

Fires the `Action<string, ulong> PlayerInfoLoaded` event with `Proof` as the argument.  
**Warning:** Does not fire if the user fails the check.

## Building this plugin
In order to build this plugin you will need access to both the Steam and Oculus Home versions of Beat Saber. The project currently uses the Steam version located on the `C:\` drive of my PC.

You need `Assembly-CSharp.dll` from the Oculus Home version, placed in a directory at the root of this repo named `.managed`.

You also need `Assembly-CSharp-firstpass.dll` from the Steam version, referenced in the game's directory.

## Thanks
|  |  |
| - | - |
| [`andruzzzhka`](https://github.com/andruzzzhka) | Giving me this idea in the first place, and having [`UserInfoPlugin`](https://github.com/andruzzzhka/UserInfoPlugin) as a great base for me to build upon. |
| [`DaNike`](https://github.com/nike4613) | For some code I shamelessly ripped out of [`BSIPA`](https://github.com/nike4613/BeatSaber-IPA-Reloaded/blob/aab06cf3ea6282e2689deb8a907f5c01899f6fe0/IPA.Loader/Utilities/BeatSaber.cs#L26) |
