=== bartyp_night_router ===
{ bartyp_night_npc_state == "new":
    -> bartyp_night_new
- else:
    -> bartyp_night_met
}

=== bartyp_night_new ===
# speaker: Hans
# portrait: BartypPortrait

HICKS.....
HICKS
Oh man was soll ich nur tun... 
Ich kann doch nich einfach nichts sagen! 
* [Haben Sie Informationen zu dem Fall"?] 
    Man ... Ja ich weiß auch nicht 
    Hier können Wir auf Jeden Fall nicht weiter reden ohne in Gefahr zu geraten. 
    Ruf mich am besten später unter dieser Nummer an: 114-420
    ~ bartyp_night_npc_state = "met"
* [Wie viel hast du denn schon getrunken?] 
    Das geht dich nen feuchten Dreck an!
    ~ bartyp_night_npc_state = "met"
    
- ->END

=== bartyp_night_met ===
# speaker: Hans
# portrait: BartypPortrait
Ich kann doch nich einfach nichts sagen! 
* [Haben Sie Informationen zu dem Fall"?] 
    Man ... Ja ich weiß auch nicht 
    Hier können Wir auf Jeden Fall nicht weiter reden ohne in Gefahr zu geraten. 
    Ruf mich am besten später unter dieser Nummer an: 114-420

* [Wie viel hast du denn schon getrunken?] 
    Das geht dich nen feuchten Dreck an!


- -> END