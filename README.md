# Lister
*"Everybody's a textfile, Dave"*

**Lister** is a small, lightweight, .NET recreation of the ls/gci/dir command from your OS/shell of choice.

Very un-featureful (currently only has two flags), **Lister** is designed for speed, efficiency, and compatibility.

Originally designed for me to use with my NeoVim plugin - [Porthole.nvim](https://github.com/Ash-Olorenshaw/Porthole.nvim) - I've actually used **Lister** in 
a number of settings just because I like that extra 100 or so ms it shaves off a query.

> ⚠️ **Note: Lister is not always faster than other options.** Lister's performance varies based on your hardware, shell of choice, etc. However, Lister is very consistent. On low end systems it tends to be considerably faster. However, on high end systems it *will* be slower than things like `ls` and `gci`, but the speed difference is usually so minimal that it is not noticeable.

## Usage

**Lister**'s usage is as follows:

```
[lister.dll] REQUIRED: [<filepath>] OPTIONAL: [-d/--directories] [-f/--files] [-h/--help]
```

If you are on Linux, to ensure that Wine doesn't try to run the application, make sure you run the program like this:
```nu-script
dotnet lister.dll ./examplefolder -f
```
with `dotnet` prepended to the command. You can easily alias this in your shell of choice to make it more simple to use

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
