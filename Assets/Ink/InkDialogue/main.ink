// ink files 
INCLUDE main_charakter.ink
INCLUDE barkeeper_npc.ink
INCLUDE bartyp_npc.ink
INCLUDE glatzkopf_npc.ink
INCLUDE obdachloser_npc.ink
INCLUDE oma_npc.ink
INCLUDE polizist_npc.ink
INCLUDE zutritt_verboten.ink
INCLUDE obdachloser_night_npc.ink
INCLUDE bartyp_night_npc.ink
INCLUDE barkeeper_night_npc.ink


// GLOBALE VARIABLEN

// Tag-System
VAR day = 1

// NPC States
VAR oma_npc_state = "new"
VAR polizist_npc_state = "new"
VAR barkeeper_npc_state = "new"
VAR bartyp_npc_state = "new"
VAR glatzkopf_npc_state = "new"
VAR obdachloser_npc_state = "new"
VAR obdachloser_night_npc_state = "new"
VAR bartyp_night_npc_state = "new"
VAR barkeeper_night_npc_state = "new"


// ENTRY POINTS

=== oma_npc ===
-> oma_router

=== polizist_npc ===
-> polizist_router

=== barkeeper_npc ===
-> barkeeper_router

=== bartyp_npc ===
-> bartyp_router

=== glatzkopf_npc ===
-> glatzkopf_router

=== obdachloser_npc ===
-> obdachloser_router

=== obdachloser_night_npc ===
-> obdachloser_night_router

=== bartyp_night_npc ===
-> bartyp_night_router

=== barkeeper_night_npc ===
-> barkeeper_night_router