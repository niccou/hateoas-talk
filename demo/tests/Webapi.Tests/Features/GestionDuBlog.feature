Feature: Gestion du blog

Background: J'ai une liste de posts au démarrage de l'api
	Given Je démarre le blog
		| Author          | State     | Title                                         | Description                                                 |
		| Andy Bloch      | Draft     | New Book: Life Lessons: Hold’em Poker Style   | Lorem ipsum dolor sit amet.                                 |
		| Andy Bloch      | Published | Poker and Blackjack training available        | Sed vel odio consequat nunc viverra mollis.                 |
		| Daniel Negreanu | Draft     | The WSOP POY Oopsie!                          | Phasellus a est sed tellus blandit cursus mollis eget odio. |
		| Daniel Negreanu | Published | Should We Care if People in the US use a VPN? | Vivamus eu faucibus erat.                                   |

@Anonyme
Scenario: En tant qu'anonyme je ne peux voir que la liste des posts publiés
	Given Je suis anonyme
	When Je veux voir le blog
	Then Je recois une liste de posts
	And Je vois uniquement les posts
		| Author          | Title                                         |
		| Andy Bloch      | Poker and Blackjack training available        |
		| Daniel Negreanu | Should We Care if People in the US use a VPN? |

@Auteur
Scenario: En tant qu'auteur sur le blog je peux voir la liste des posts publiés et mes posts en brouillon
	Given Je suis Daniel Negreanu
	When Je veux voir le blog
	Then Je recois une liste de posts
	And Je vois uniquement les posts
		| Author          | Title                                         |
		| Andy Bloch      | Poker and Blackjack training available        |
		| Daniel Negreanu | The WSOP POY Oopsie!                          |
		| Daniel Negreanu | Should We Care if People in the US use a VPN? |

@Anonyme
Scenario: En tant qu'anonyme je consulte le détail d'un post
	Given Je suis anonyme
	When Je veux voir le blog
	And Je veux voir le post Poker and Blackjack training available
	Then Je recois un détail de post
	And Le détail du post est
		| Author          | Title                                         | Description                                 |
		| Andy Bloch      | Poker and Blackjack training available        | Sed vel odio consequat nunc viverra mollis. |
