# Lister
*"Everybody's a textfile, Dave"*

**Lister** is a small, lightweight, .NET recreation of the ls/gci/dir command from your OS/shell of choice.

Very un-featureful (currently only has four meaningful flags), **Lister** is designed for compatibility, speed, and efficiency.

Originally designed for me to use with my NeoVim plugin - [Porthole.nvim](https://github.com/Ash-Olorenshaw/Porthole.nvim) - I've actually used **Lister** in 
a number of settings just because I like that extra 100 or so ms it shaves off a query on low end hardware.

> ⚠️ **Note: Lister is not always faster than other options.** Lister's performance varies based on your hardware, shell of choice, etc. However, Lister is very consistent. On low end systems it tends to be considerably faster. However, on high end systems it *will* be slower than things like `ls` and `gci`, but the speed difference is usually so minimal that it is not noticeable.

## Usage

**Lister** is built on .NET (9) - if you don't have it installed, do the following:
```nu-script
# Fedora
sudo dnf update
sudo dnf install dotnet

# Windows
winget install Microsoft.DotNet.DesktopRuntime.9
```
(For Ubuntu, or any other Linux distro, follow these instructions [here](https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu))

After .NET is installed, **Lister**'s usage is as follows:

```
[Lister.dll] REQUIRED: [<filepath>] OPTIONAL: [-d/--directories] [-f/--files] [-c/--coloured/--colored] [-i/--ignore] [-h/--help]
```

On all platforms, make sure you run the program with `dotnet` prepended to the command like this:
```nu-script
dotnet lister.dll ./examplefolder
```
This is to stop Linux trying to run it with Wine and Windows complaining that it's a system element. 

You can easily alias this in your shell of choice like this:

```pwsh
# PowerShell - in your $PROFILE
function RunLister {
	dotnet "/path/to/your/lister/install/Lister.dll" @args
}

Set-Alias -Name lister -Value RunLister
```
```bash
# Bash - in your .bashrc
function RunLister {
	dotnet "/path/to/your/lister/install/Lister.dll" "$@"
}

alias lister=RunLister
```

## Building

If you want to build Lister yourself, do the following:

```nu-script
# download the files
git clone "https://github.com/Ash-Olorenshaw/Lister.git"

# cd into the directory
cd Lister

# install all packages
dotnet restore

# compile
dotnet publish -o ./releases/
```

All you need out of the 'releases' folder then is usually just `FSharp.Core.dll`, `Lister.dll` and `Lister.runtimeconfig.json`.
