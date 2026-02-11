=== polizist_router ===
{ polizist_npc_state == "new":
    -> polizist_new
- else:
    -> polizist_met
}

=== polizist_new ===
# speaker: Polizist
# portrait: PolizistPortrait

Aha Sie sind also diese Reporter...
Ich sags gleich wie es ist
Es handelt sich hier um einen Klaren Fall

* [Was meinen Sie mit einem "Klaren Fall"?] 
    Ich habe genug Erfahrung gesammelt um zu wissen wie diese Leute ticken.
    Also eindeutig ein Familien Verbrechen
    ~ polizist_npc_state = "met"
* [Was für Untersuchungen wurden angestelt?] 
    Wir haben die Tatwaffe sichergestellt und warten jetzt auf was das Labor sagt.
    Mehr kann man da gerade nicht tun.
    ~ polizist_npc_state = "met"
* [Gab es Augenzeugen?] 
    Nein
    ....
    Naja doch, aber da war nichts Hilfreiches dabei
    ~ polizist_npc_state = "met"
    
- ->END
    
Aber irgendwie denke ich, dass da doch noch etwas war ... aber was nur.
-> END

=== polizist_met ===
# speaker: Polizist
# portrait: PolizistPortrait
Es handelt sich hier um einen Klaren Fall

* [Was meinen Sie mit einem "Klaren Fall"?] 
    Ich habe genug Erfahrung gesammelt um zu wissen wie diese Leute ticken.
    Also eindeutig ein Familien Verbrechen

* [Was für Untersuchungen wurden angestellt?] 
    Wir haben die Tatwaffe sichergestellt und warten jetzt auf was das Labor sagt.
    Mehr kann man da gerade nicht tun.

* [Gab es Augenzeugen?] 
    Nein
    ....
    Naja doch, aber da war nichts Hilfreiches dabei
    ~ polizist_npc_state = "met"
    
- ->END