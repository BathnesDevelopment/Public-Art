# Public Art Data Export

Export scripts to take data from the Public Art admin system and .

## What is it?

As part of the refresh of the public art admin system it was decided that we would export the data to the Bath: Hacked data store.

However, the public art system is a relational SQL Server database, with images stored in the database (using Filestream).  Datasets held in the data store are generally 