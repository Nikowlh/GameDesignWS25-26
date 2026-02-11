=== obdachloser_night_router ===
{ obdachloser_night_npc_state == "new":
    -> obdachloser_night_new
- else:
    -> obdachloser_night_met
}

=== obdachloser_night_new ===
# speaker: Max
# portrait: ObdachloserPortrait

Scheiße! Scheiße! Ich habe wohl doch zu viel gesagt! 

Vielleicht suche ich mir einen Neuen Park. 
~ obdachloser_night_npc_state = "met"
-> END

=== obdachloser_night_met ===
# speaker: Max
# portrait: ObdachloserPortrait
    
Alles deine Schuld! Was legst du dich denn auch mit solchen Leuten an? 

- -> END