using Godot;
using System;



 


public partial class main : Node2D
{
		// game vars
	int score;
	bool game_started = false;

	// game variables
	int cells = 20;
	int cell_size = 50;
	// snake vars
	int[] old_data;
	int[] snake_data;
	PackedScene[] snake;

	//movement vars
	int[] start_pos = {9, 9};
	int[] up = {0, -1};
	int[] down = {0, 1};
	int[] left = {-1, 0};
	int[] right = {1, 0};
	int[] move_direction;
	bool can_move = true;
	
	public void new_game() {
		score = 1;
		Label ScoreText = GetNode<Label>("Background/Hud/Score"); 
		ScoreText.Text = "SCORE: " + $"{score}";
		move_direction = up;
		can_move = true;
		//generate_snake();
	} 

	[Export] public PackedScene snake_scene;
	// Called when the node enters the scene tree for the first time.
	
	
	public override void _Ready()
	{
		new_game();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		float AMOUNT = 5;
		if (Input.IsKeyPressed(Key.W)) {
			GetNode<Label>("Background/Hud/Score").Text = "Test";
		}
	}
}


