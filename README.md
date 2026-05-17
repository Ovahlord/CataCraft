**Introduction**

CataCraft is an Open Source emulator for WoW Cataclysm 4.3.4.15595 and is published under the MIT license.
The software is currently in a highly experimental state and expected to remain as such for a longer period of time.

___

**Technologies used**

- C# and .NET 10 (We will always update to the latest .NET version when available)
- Entity Framework Core for database management
- BouncyCastle for RSA SHA 1 specific cryptographic use cases

**Supported Database Management Systems (DBMS)**

- SQLite

Support for MariaDB and PostgresSQL is scheduled for implementation after the initial framework has been fleshed out

___
**Installation**

Just compile the source code and jump into the bin folder until you find the CataCraft.exe file. In that folder you will find an appsettings.json file.
Change the DBC path and locale to whatever files you have available. Once you're done, just run the .exe file and wait a bit until the DBCs have been loaded and the database created.
Once this is done, you can jump right in by using your localhost address in your realmlist.
___

**Contribution Guidelines**

If you want to participate in the development of the software, feel free to join. There are certain rules to follow which are as following:
- No AI generated code. We do not advocate against using AI for assistance, but we do not accept fully generated code. We expect you to know what you are doing.
- No 'unsafe' code. The usage of the 'unsafe' keyword, pointers etc is strictly prohibited. We work exclusively with managed code.
- Try not to make the code complicated for the sake of being complicated. We want to keep the entry barrier low so that new contributors won't get scared off. No need to flex around.
- Follow the code style and formatting rules suggested by the .editorconfig of this repository. Custom formatting won't be tolerated.

___

**Disclaimer**

This project is purely for educational purposes and is not intended to be used to operate so called 'private servers'. We heavily advise anyone to refrain from using this software for operating such servers in order to avoid possible legal consequences.
