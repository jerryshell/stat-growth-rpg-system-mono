using Godot;

public partial class GUI : Control
{
	public Player Player;

	Label Class;
	Label Level;
	Label ProficiencyBonus;
	Label XP;
	Label Health;
	Label Strength;
	Label Dexterity;
	Label Constitution;
	Label Intelligence;
	Label Wisdom;
	Label Charisma;
	ProgressBar XPProgressBar;
	Button GainXP;

	public override void _Ready()
	{
		Class = GetNode<Label>("%Class");
		Level = GetNode<Label>("%Level");
		ProficiencyBonus = GetNode<Label>("%ProficiencyBonus");
		XP = GetNode<Label>("%XP");
		Health = GetNode<Label>("%Health");
		Strength = GetNode<Label>("%Strength");
		Dexterity = GetNode<Label>("%Dexterity");
		Constitution = GetNode<Label>("%Constitution");
		Intelligence = GetNode<Label>("%Intelligence");
		Wisdom = GetNode<Label>("%Wisdom");
		Charisma = GetNode<Label>("%Charisma");
		XPProgressBar = GetNode<ProgressBar>("%XPProgressBar");
		GainXP = GetNode<Button>("%GainXP");
		GainXP.Pressed += GainXPPressed;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		Update();
	}

	public void Update()
	{
		if (Player == null)
		{
			return;
		}
		Class.Text = Player.CharacterClass.Name;
		Level.Text = Player.Stat.Level.Value.ToString();
		ProficiencyBonus.Text = Player.Stat.Level.ProficiencyBouns().ToString();
		XP.Text = Player.Stat.Level.Xp.ToString();
		Health.Text = $"{Player.Stat.Health.Value}/{Player.Stat.Health.MaxValue}";
		Strength.Text = $"{Player.Stat.Strength.Value} ({Player.Stat.Strength.Modifier():+#;-#;+0})";
		Dexterity.Text = $"{Player.Stat.Dexterity.Value} ({Player.Stat.Dexterity.Modifier():+#;-#;+0})";
		Constitution.Text = $"{Player.Stat.Constitution.Value} ({Player.Stat.Constitution.Modifier():+#;-#;+0})";
		Intelligence.Text = $"{Player.Stat.Intelligence.Value} ({Player.Stat.Intelligence.Modifier():+#;-#;+0})";
		Wisdom.Text = $"{Player.Stat.Wisdom.Value} ({Player.Stat.Wisdom.Modifier():+#;-#;+0})";
		Charisma.Text = $"{Player.Stat.Charisma.Value} ({Player.Stat.Charisma.Modifier():+#;-#;+0})";
		// XPProgressBar
		var levelXp = Player.Stat.Level.LevelXp();
		var nextLevelXp = Player.Stat.Level.NextLevelXp();
		XPProgressBar.MaxValue = nextLevelXp - levelXp;
		XPProgressBar.Value = Player.Stat.Level.Xp - levelXp;
	}

	public void GainXPPressed()
	{
		Player.Stat.Level.Xp += 130;
	}
}
