# RadeonWindowFix
_Fix glassy effect or border only bug on Radeon Software_

## Requirements

* .NET Framework 4
* Visual Studio Tools to compile C# code _(if you want to build from source)_

### How to use ?

1. Clone repository, and build from source with Visual Studio **(optional)**
1. (alt) - Download latest version of RadeonWindowFix.exe from '**Release**' tab
2. Run RadeonWindowFix.exe _(will be automatically escalated)_
3. You're done !

### Troubleshooting

* **RWF fails to close a process** | Don't worry, this process might be running with higher privileges, it's a good thing it didn't succeeded to close it
* **RWF failed to reopen a process** | That should never happen, but if so, try to restart it manually, or restart your computer
* **RWF didn't fixed the issue** | Report it via '**Issue**' tab with the maximum of informations, I'll try to investigate
* _alternate solution, try to re-install the driver (use this only as your **ultimate** solution)_