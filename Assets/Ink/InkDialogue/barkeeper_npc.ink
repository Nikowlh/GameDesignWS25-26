=== barkeeper_router ===
{ barkeeper_npc_state == "new":
    -> barkeeper_new
- else:
    -> barkeeper_bier
}

=== barkeeper_new ===
# speaker: Barkeeper
# portrait: BarkeeperPortrait

Der Drink geht aufs Haus 

-> END

=== barkeeper_bier ===
# speaker: Barkeeper
# portrait: BarkeeperPortrait
Ein Bier? 
    * [Ja, aber in der Flasche bitte] 
        Kommt sofort! 
        ~ obdachloser_npc_state = "bier"
        ~ barkeeper_npc_state = "new"
    
    * [Nein, gerade nicht] 
        Alles Klar. Geb bescheid wenn es doch was sein darf 
         ~ barkeeper_npc_state = "bier"

- -> END