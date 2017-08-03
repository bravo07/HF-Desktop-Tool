# HF Desktop Tool
### Current version : v1.2.2

## Features
* Shows your avatar, and usergroup.
* Changes your username color to your group (Even for you Omni, even though you won't use this <3)
* Shows Reputation, Post count, and Account age(in days).
* Notifies you when you get positive rep or when you receive a new pm.
* Save APIKey for easy login. (Locally ofc.)
* Will display a message if you have unread PMs.
* Notifications will tell you have many unread PMs you have.

## Screenshots : 
##### Login form :

![Login](https://i.gyazo.com/47e909c2214c4e970a1d589037ca5611.png)

##### Main tab : 


![Main](https://i.gyazo.com/cdeac8ff05943326cfb2fd31e38fdb6d.png)

##### Main tab with unread PMs. : 


![Main](https://i.gyazo.com/057aba6cb35ab4a6f97bf7a83ad2e993.png)

##### Settings tab : 


![Settings](https://i.gyazo.com/f621e85ce7b81f3fce2d5318a67fe4ae.png)


## Known Issues & WIPs.
~~* To prevent calling the API too many times, too fast you'll get your PM count the first time the application refreshes your info (every 45 seconds).~~
* The application will break if you exceed the 240 calls/ our limit. The application makes about 180 calls an hour.

## Changelog:
#### Version 1.0
* Released.

#### Version 1.1
* Major UI Improvement, incorporating the HF background.
* Colored Username depending on user group (Theres one for Ub3r, L33t, Staff, and Mr. Omni <3)
* Removed some settings
* Major code improvement
* Heavily commented
* The aliens have landed.

#### Version 1.2
* Now uses "?include=header" so only 1 call is necessary to update all user information.
* 403 Errors from the API are much less likely due to the application only calling it once every 20 seconds.
* Calls the API 20 times a second meaning around 180 calls are made every hour.
* Added a linked label to display when there are unread PMs.
* PM Notifications now tell you how many unread PMs you have.
* Removed PM Count
* PM Count is replaced by account age (in days).

#### Version 1.2.2
* Fixed Issues : The userbar would always give the user the l33t userbar.
* HF-Uploaded Avatars won't throw an illegal characters error.
