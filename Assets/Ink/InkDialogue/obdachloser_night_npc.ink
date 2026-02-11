=== obdachloser_night_router ===
{ obdachloser_night_npc_state == "new":
    -> obdachloser_night_new
- else:
    -> obdachloser_night_met
}

=== obdachloser_night_new ===
# speaker: Obdachloser
# portrait: ObdachloserPortrait

Es ist so kalt ... 

-> END

=== obdachloser_night_met ===
# speaker: Obdachloser
# portrait: ObdachloserPortrait

- -> END