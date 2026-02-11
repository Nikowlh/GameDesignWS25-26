=== oma_router ===
{ oma_npc_state == "new":
    -> oma_new
- else:
    -> oma_met
}

=== oma_new ===
# speaker: Oma
# portrait: OmaPortrait

Ach… Sie sind doch dieser Reporter, nicht wahr?
So eine Tragödie… ganz schrecklich…
Er war ja eigentlich ganz nett… für einen von denen.


* [Was meinen Sie mit "von denen"?] 
    Ach, jetzt tun Sie doch nicht so. Man wird ja wohl noch sagen dürfen…
    Diese Leute bringen eben… Unruhe rein. Aber er war höflich. Immer gegrüßt.
    ~ oma_npc_state = "met"
* [Sie kannten das Opfer gut?] 
    Er hat mir manchmal die Tür aufgehalten. Und einmal hat er meiner Nachbarin kostenlos die Haare geschnitten.
    ~ oma_npc_state = "met"
* [Haben Sie am Tatabend etwas gesehen?]
    Ach du liebes Bisschen! Ich bitte Sie.
    ~ oma_npc_state = "met"
* [Was genau ist hier passiert?]
    Die Polizei sagt ja, es ist wohl eine interne Sache. Das überrascht mich nicht.
    ~ oma_npc_state = "met"
    
- ->END
    
Aber irgendwie denke ich, dass da doch noch etwas war ... aber was nur.

=== oma_met ===
# speaker: Oma
# portrait: OmaPortrait

Er war ja eigentlich ganz nett… für einen von denen.

* [Was meinen Sie mit "von denen"?] 
    Ach, jetzt tun Sie doch nicht so. Man wird ja wohl noch sagen dürfen…
    Diese Leute bringen eben… Unruhe rein. Aber er war höflich. Immer gegrüßt.
    
* [Sie kannten das Opfer gut?] 
    Er hat mir manchmal die Tür aufgehalten. Und einmal hat er meiner Nachbarin kostenlos die Haare geschnitten.

* [Haben Sie am Tatabend etwas gesehen?]
    Ach du liebes Bisschen! Ich bitte Sie.

* [Was genau ist hier passiert?]
    Die Polizei sagt ja, es ist wohl eine interne Sache. Das überrascht mich nicht.
    
Aber irgendwie denke ich, dass da doch noch etwas war ... aber was nur.

--> END
