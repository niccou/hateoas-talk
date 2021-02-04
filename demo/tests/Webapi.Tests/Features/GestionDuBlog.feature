Feature: Gestion du blog

Background: J'ai une liste de posts au démarrage de l'api
	Given Je démarre l'api avec les posts suivant
		| Author          | State     | Title                                         | Description                                                 |
		| Andy Bloch      | Draft     | New Book: Life Lessons: Hold’em Poker Style   | Lorem ipsum dolor sit amet.                                 |
		| Andy Bloch      | Published | Poker and Blackjack training available        | Sed vel odio consequat nunc viverra mollis.                 |
		| Daniel Negreanu | Draft     | The WSOP POY Oopsie!                          | Phasellus a est sed tellus blandit cursus mollis eget odio. |
		| Daniel Negreanu | Published | Should We Care if People in the US use a VPN? | Vivamus eu faucibus erat.                                   |

Scenario: En tant qu'anonyme je ne peux voir que la liste des
	Given Je suis anonyme
	When Je veux voir le blog
	Then Je recois une liste de posts
	And Je vois uniquement les posts
		| Author          | Title                                         | Description                                 |
		| Andy Bloch      | Poker and Blackjack training available        | Sed vel odio consequat nunc viverra mollis. |
		| Daniel Negreanu | Should We Care if People in the US use a VPN? | Vivamus eu faucibus erat.                   |