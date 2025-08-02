using Godot;
using SceneManagement;
using System;

public partial class SceneInitPlayer : Node {
	const string PlayerObjectFilePath = "res://specificzone/Player.tscn"; // Replace

	public override void _Ready() {
		base._Ready();
		CharacterBody2D player = (CharacterBody2D)GD.Load<PackedScene>(PlayerObjectFilePath).Instantiate();
		player.Position = SceneManager.SpawnPoint;
		AddChild(player);
	}

}
