=== bartyp_router ===
{ bartyp_npc_state == "new":
    -> bartyp_new
- else:
    -> bartyp_met
}

=== bartyp_new ===
# speaker: Hans
# portrait: BartypPortrait

Was Zitterst du denn so?

-> END

=== bartyp_met ===
# speaker: Hans
# portrait: BartypPortrait

- -> END