=== glatzkopf_router ===
{ glatzkopf_npc_state == "new":
    -> glatzkopf_new
- else:
    -> glatzkopf_met
}

=== glatzkopf_new ===
# speaker: Glatzkopf
# portrait: GlatzkopfPortrait

Was Zitterst n du so?

-> END

=== glatzkopf_met ===
# speaker: Glatzkopf
# portrait: GlatzkopfPortrait

- -> END