using Godot;

public partial class Player : CharacterBody2D
{
	public CharacterClass CharacterClass;
	public CharacterStat Stat;

	AnimatedSprite2D AnimatedSprite2D;
	AudioStreamPlayer2D AudioStreamPlayer2D;

	public override void _Ready()
	{
		AnimatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		AudioStreamPlayer2D = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");

		CharacterClass = new Barbarian();
		Stat = CharacterClass.CreateBaseStat();

		Stat.Level.LevelUp += OnLevelUp;
	}

	void OnLevelUp()
	{
		CharacterClass.OnLevelUp(Stat);
		AnimatedSprite2D.Stop();
		AnimatedSprite2D.Play("level_up");
		AudioStreamPlayer2D.Play();
	}
}
