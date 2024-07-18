using Godot;
using System;
using System.Collections.Generic;


 


public partial class main : Node2D
{
		// game vars
	int score;
	bool game_started = false;

	// game variables
	int cells = 20;
	int cell_size = 45;
	// snake vars
	List<Vector2> old_data = new List<Vector2>();
	List<Vector2> snake_data  = new List<Vector2>();
	List<Panel> snake = new List<Panel>();

	//movement vars
	Vector2 start_pos = new Vector2(9, 7);
	Vector2 up = new Vector2(0, -1);
	Vector2 down = new Vector2(0, 1);
	Vector2 left = new Vector2(-1, 0);
	Vector2 right = new Vector2(1, 0);
	Vector2 move_direction;
	bool can_move = true;
	
	public PackedScene snake_scene;
	public Timer MovementTimer;
	
	public void new_game() {
		snake_scene = (PackedScene)GD.Load("res://scenes/snake_segment.tscn");
		score = 0;
		Label ScoreText = GetNode<Label>("Hud/Score"); 
		ScoreText.Text = "SCORE: " + $"{score}";
		move_direction = up;
		can_move = true;
		generate_snake();
		MovementTimer = GetNode<Timer>("MovementTimer");
	} 
	
	public void generate_snake() {
		old_data.Clear();
		snake_data.Clear();
		snake.Clear();
		
		for(int i = 0; i < 3; i++) {
			//add_segment(start_pos + new Vector2(0,1));
			Vector2 pos = new Vector2(start_pos[0],start_pos[1]+i+0.1f);
			add_segment(pos);
		}
	}
	
	public void add_segment(Vector2 pos) {
		snake_data.Add(pos);
		Panel SnakeSegment = (Panel)snake_scene.Instantiate();
		SnakeSegment.Position = (pos * cell_size) + new Vector2(0, cell_size);
		AddChild(SnakeSegment);
		snake.Add(SnakeSegment);
		GD.Print("reached");
	}

	public void start_game() {
		game_started = true;
		MovementTimer.Start();
	}
	
	public void move_snake() {
		if (can_move) {
			if (Input.IsActionJustPressed("move_down") && move_direction != up) {
				move_direction = down;
				can_move = false;
				if (!game_started) {
					start_game();
				}
			}
			if (Input.IsActionJustPressed("move_up") && move_direction != down) {
				move_direction = up;
				can_move = false;
				if (!game_started) {
					start_game();
				}
			}
			if (Input.IsActionJustPressed("move_right") && move_direction != left) {
				move_direction = right;
				can_move = false;
				if (!game_started) {
					start_game();
				}
			}
			if (Input.IsActionJustPressed("move_left") && move_direction != right) {
				move_direction = left;
				can_move = false;
				if (!game_started) {
					start_game();
				}
			}
		}
	}
	// Called when the node enters the scene tree for the first time.
	
	
	public override void _Ready()
	{
		new_game();
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		move_snake();
	}
	
	private void _on_movement_timer_timeout()
	{
		can_move = true;
		
		//old_data = [] + snake_data;
		//snake_data[0] += move_direction;
		//for (int i = 0; i < )
	}
}





