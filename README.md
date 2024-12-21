# Lister
*"Everybody's a textfile, Dave"*

**Lister** is a small, lightweight, .NET recreation of the ls/gci/dir command from your OS/shell of choice.

Very un-featureful (currently only has two flags), **Lister** is designed for speed, efficiency, and compatibility.

Originally designed for me to use with my NeoVim plugin - [Porthole.nvim](https://github.com/Ash-Olorenshaw/Porthole.nvim) - I've actually used **Lister** in 
a number of settings just because I like that extra 100 or so ms it shaves off a query.

> ⚠️ **Note: Lister is not always faster than other options.** On higher end systems I have noticed it perform worse by 40 or so ms (not really noticeable in my
> opinion, but still worse). Lister best performs on lower-end systems for some reason - I don't fully understand why, but that's the way it works...

## Usage

**Lister**'s usage is as follows:

```
[lister.dll] REQUIRED: [<filepath>] OPTIONAL: [-d/--directories] [-f/--files] [-h/--help]
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

All you need out of the 'releases' folder then is usually just `FSharp.Core.dll`, `Lister.dll` and `Lister.deps.json`.
