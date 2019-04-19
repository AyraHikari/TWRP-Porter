# TWRP Porter

[![PayPal](https://www.paypalobjects.com/webstatic/mktg/Logo/pp-logo-200px.png)](https://paypal.me/AyraHikari)

## Screenshot

[![Screenshot](https://raw.githubusercontent.com/AyraHikari/TWRP-Porter/master/TWRPPorter.png)](https://raw.githubusercontent.com/AyraHikari/TWRP-Porter/master/TWRPPorter.png)

### How to use:

```
Base = Base TWRP for your device
Target = Target TWRP you want to port
```

* Browse base TWRP
* Browse target TWRP
* You can extract it manual and edit it manual, or Select Auto Port if you dont know or lazy for modding it
* After that, it will build twrp automatic, so wait for it
* After build success, try flash recovery.img

## Report a bug or request a feature

You can report a bug or request a feature by [opening an issue](https://github.com/AyraHikari/TWRP-Porter/issues/new).

#### How to report a bug
* A detailed description of the bug
* Make sure there are no similar bug reports already

#### How to request a feature
* A detailed description of the feature
* All kind of information
* How to apply a new value
* Make sure there are no similar feature requests already

## Download & Build

Clone the project and type this :
	
```
"C:\Program Files (x86)\MSBuild\14.0\Bin\MsBuild.exe" "TWRP Porter.sln" /t:Clean,Build /p:Configuration=Release /p:TargetFramework=v3.0
```

## Credits

I used following binaries:

* Cofface: [bootimg binary](https://github.com/cofface/android_bootimg)

## License

    Copyright (C) 2018 Tedy Ramdani <tedyramadhani2@gmail.com>
    
    TWRP Porter is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    
    TWRP Porter is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    
    You should have received a copy of the GNU General Public License
    along with TWRP Porter.  If not, see <http://www.gnu.org/licenses/>.
