using System;
using UnityEngine;

	public class Progress
	{
		public int m_Score;
		public int m_Level;
		public string m_LevelName;
		public float m_Progress;
	public int m_PointsToNextLevel;

	int[] Scores = new int[] { 200, 400, 700, 1000, 1500, 2000, 2500, 3000, 4000, 5000, 7500, 10000, 15000, 20000, 25000, 50000, 75000, 100000 };
	string[] Names = new string[] {"Beginner", "Occasional Environment Observer", "Environment Observer", "Advanced Environment Observer", "Professional Environment Observer", "Legend Environment Observer", "Occasional Environment Protector", "Environment Protector", "Advanced Environment Protector", "Professional Environment Protector", "Legend Environment Protector", "Ecowarrior", "Advanced Ecowarrior", "Master Ecowarrior", "Mega Ecowarrior", "Legend Ecowarrior", "Occasional Environmental Scientist", "Environmental Scientist", "Advanced Environmental Scientist", "Professional Environmental Scientist", "Legend Environmental Scientist"};
	string[] NamesGer = new string[] {"Anfänger", "Gelegentlicher Umweltbeobachter", "Umweltbeobachter", "Fortgeschrittener Umweltbeobachter", "Professioneller Umweltbeobachter", "Legendärer Umweltbeobachter", "Gelegentlicher Umweltschützer", "Umweltschützer", "Fortgeschrittener Umweltschützer", "Professioneller Umweltschützer", "Legendärer Umweltschützer", "Umweltkämpfer", "Fortgeschrittener Umweltkämpfer", "Meister Umweltkämpfer", "Mega Umweltkämpfer", "Legendärer Umweltkämpfer", "Gelegentlicher Umweltwissenschaftler", "Umweltwissenschaftler", "Fortgeschrittener Umweltwissenschaftler", "Professioneller Umweltwissenschaftler", "Legendärer Umweltwissenschaftler"};

	public Progress (int score)
	{
		Debug.Log ("Progress score: " + score);

		int index = 0;
		while (index < Scores.Length && score >= Scores [index]) {
			index++;
		}

		Debug.Log ("Progress index: " + index);


		m_Level = index + 1;

		if (Application.systemLanguage == SystemLanguage.German) {
			m_LevelName = NamesGer [index];
		} else {
			m_LevelName = Names [index];
		}

		if (index < Scores.Length) {
			float minvalue = 0.0f;
			if (index > 0) {
				minvalue = Scores [index - 1];
			}
			float maxvalue = Scores [index];



			m_Progress = (score - minvalue) / (maxvalue-minvalue);

			m_PointsToNextLevel = (int)maxvalue - score;
		} else {
			m_Progress = 1.0f;
		}
	}


}


