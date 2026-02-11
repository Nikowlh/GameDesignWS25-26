=== bartyp_night_router ===
{ bartyp_night_npc_state == "new":
    -> bartyp_night_new
- else:
    -> bartyp_night_met
}

=== bartyp_night_new ===
# speaker: Bartyp
# portrait: BartypPortrait

Ey Ich liebe dich doch so sehr!!!!

-> END

=== bartyp_night_met ===
# speaker: Bartyp
# portrait: BartypPortrait

- -> END