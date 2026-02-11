=== obdachloser_router ===
{ obdachloser_npc_state == "new":
    -> obdachloser_new
- else: 
    -> obdachloser_bier
}   

=== obdachloser_new ===
# speaker: Max
# portrait: ObdachloserPortrait

Bisschen Kleingeld?

Hm? Ob ich was von dem Mord weiß? 

Naja, sagen wir mal so...

Bei einem Bierchen würde ich mich wahrscheinlcih an das ein oder andere Erinnern.

Also? Kaufst du mir in der Bar ein Bier?

* [Ja, mach ich!] 
    Perfekt! Dann warte ich hier solange.
    ~ barkeeper_npc_state = "bier"
    
* [Nein, für sowas habe ich keine Zeit!] 
    Pff! Dann zisch ab, wenn du es dir nicht anders überlegst.

--> END

=== obdachloser_bier ===
# speaker: Max
# portrait: ObdachloserPortrait

Ahhh! Du hast mir ja wirklich eins geholt. 
Danke dir!
GLUCK GLUCK GLUCK
.....
..... .....
    * [Und? Hast du jetzt was gesehen?] 
    Achsoo ja stimmt. Hatte ich ganz vergessen.
    Gesten Abend also.... 
    Ich habe auf jeden Fall etwas gehört. 
    Einen Streit... den hätte aber in der Nähe jeder gehört also ist wahrscheinlich nichts Neues für dich. 
    Mehr will ich da zu meiner Sicherheit jetzt auch nicht sagen! 
    ~ obdachloser_npc_state = "angst"
    
-> END
