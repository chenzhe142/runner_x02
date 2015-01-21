======================
= Unity game: Runner =
= name: Zhe Chen     =
======================

tutorial link:
   Runner
   http://catlikecoding.com/unity/tutorials/runner/
   
play online:
   https://19c726b3c197b069bf268c9917500ff1aaaa57a7.googledrive.com/host/0B2eCMbJ8NpDgU0tIR3FDR2dwdmc/runner_x01.html

Feature:
- added multiple platforms (upper platform, and lower platform) in game, player can control cube move up or down through "jumper".

- added "jumper" and "upper"
	- jumper: jump higher than booster
		Green capsule showed in game.
		Randomly show up in every platform.

		When player cube collides with jumper, cube will directly jump higher without pressing "enter".

	- upper: add extra 20 points on total score
		red capsule showed in game.
		Only randomly show up in center platform.

		When player cube collides with upper, the score will be added by 20, and immediately updated on screen.

- added new physics material for upper platform, with different color.
