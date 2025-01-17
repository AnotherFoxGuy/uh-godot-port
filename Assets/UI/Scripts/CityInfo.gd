tool
extends HBoxContainer
# Info widget displaying generic information about the hovered city.

const Global = preload("res://Assets/World/Global.gd")

const FACTION_SETTLEMENT = [
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement.png"), # neutral
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_red.png"),
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_blue.png"),
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_dark_green.png"),
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_orange.png"),
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_purple.png"),
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_cyan.png"),
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_yellow.png"),
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_pink.png"),
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_teal.png"),
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_lime_green.png"),
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_bordeaux.png"),
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_white.png"),
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_gray.png"),
	preload("res://Assets/UI/Icons/Widgets/CityInfo/settlement_black.png")
]

export(Global.Faction) var faction := 0 setget set_faction
export(bool) var debug_cycle_factions := false setget debug_set_cycle_factions

onready var faction_settlement := $SettlementName/FactionSettlement
onready var animation_player := $AnimationPlayer

func _ready() -> void:
	if not Engine.is_editor_hint():
		visible = false

func set_faction(new_faction: int) -> void:
	if not is_inside_tree(): yield(self, "ready")

	faction = new_faction
	faction_settlement.texture = FACTION_SETTLEMENT[faction]

	property_list_changed_notify()

func debug_set_cycle_factions(new_debug_cycle_factions: bool) -> void:
	if not is_inside_tree(): yield(self, "ready")

	debug_cycle_factions = new_debug_cycle_factions
	if debug_cycle_factions:
		$Timer.start()
	else:
		$Timer.stop()

func show() -> void:
	if animation_player.is_playing():
		animation_player.stop(false)
	animation_player.play("fade_in")

func hide() -> void:
	if animation_player.is_playing():
		animation_player.stop(false)
	animation_player.play_backwards("fade_in")

func _on_Timer_timeout() -> void:
	self.faction = wrapi(faction + 1, 0, FACTION_SETTLEMENT.size())

func _on_AnimationPlayer_animation_started(anim_name: String) -> void:
	match anim_name:
		"fade_in":
			visible = true

func _on_AnimationPlayer_animation_finished(anim_name: String) -> void:
	match anim_name:
		"fade_out":
			visible = false
