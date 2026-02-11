=== glatzkopf_router ===
{ glatzkopf_npc_state == "new":
    -> glatzkopf_new
- else:
    -> glatzkopf_met
}

=== glatzkopf_new ===
# speaker: ???
# portrait: GlatzkopfPortrait

Hey Du! 
Du bist also der Reporter von dem man gerade so viel hört. 
Für jemanden, der neu in der Stadt ist, bewegen Sie sich ziemlich… neugierig.
Konzentrieren Sie sich lieber auf die Familie.
Da finden Sie bestimmt, was Sie suchen.
~ glatzkopf_npc_state = "met"

-> END

=== glatzkopf_met ===
# speaker: ???
# portrait: GlatzkopfPortrait

Unfälle passieren schnell. Besonders, wenn man sich in fremde Angelegenheiten einmischt. 
~ glatzkopf_npc_state = "met"
- -> END