=== barkeeper_night_router ===
{ barkeeper_night_npc_state == "new":
    -> barkeeper_night_new
- else:
    -> barkeeper_night_met
}

=== barkeeper_night_new ===
# speaker: Barkeeper
# portrait: BarkeeperPortrait

Der Drink geht aufs Haus 

-> END

=== barkeeper_night_met ===
# speaker: Barkeeper
# portrait: BarkeeperPortrait

- -> END