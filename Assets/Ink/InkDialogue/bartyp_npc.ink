=== bartyp_router ===
{ bartyp_npc_state == "new":
    -> bartyp_new
- else:
    -> bartyp_met
}

=== bartyp_new ===
# speaker: Bartyp
# portrait: BartypPortrait

Was Zitterst du denn so?

-> END

=== bartyp_met ===
# speaker: Bartyp
# portrait: BartypPortrait

- -> END