# Asgard
Basic implementation of serial comms for talking to MERG CBUS using GridConnect.

This contains the basic code used in CbusLogger; the intention is to turn it into a nuget package so that it become easier for a C#.NET developer to develop applications that interface with MERG CBUS modules.

It supports logging using NLog; there is also a dependency on Unity, which is currently not used.

The latest version of cbusdefsenums from MERG Devs is embedded; when (if) this is turned into a Nuget package in its own right this will have a dependency on it. Until then any update will need to be manually updated here and a new version released.