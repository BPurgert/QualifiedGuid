The Qualified GUID (QUID)

The Qualified GUID (QUID) is designed to be used in testing situations where you want to be 
able to identity test data. The QUID always starts with 555, inspired by Hollywood phone numbers.
The QUID stores the time it was generated and, optionally, an ID for the user or system that 
generated the QUID. There are 12 bits available for user / application specific data. 8 bits 
are reserved for future use. 

FORMAT

00000000-0000-0000-0000-000000000000

Going to call this v1 variant c and Hard code bits 0-12 with with 555

55500000-0000-1000-c000-000000000000

6548C7C1

Bits 13-40 Add the epoch timestamp (as hex) 6548C96E

5556548C-96E0-1000-c000-000000000000

Optional - 1 byte for the ID for the user or system this was generated from 75, 
placed in bits 45-48 and 53-56 (split because of the version bits) 

5556548C-96E7-1500-c000-000000000000
32-16-16-16-48
Last 6 bytes (12 characters) are random.
That gives you 16 million guids per second per user.


Bits 57-64 are reserved for future use.
Bits 69-80 are user defined bits. 

Bits 81-127

