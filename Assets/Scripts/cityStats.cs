using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cityStats : MonoBehaviour {


	public float population = 1000;
	public float availableJobs = 700;
	public int averageIncome = 20000;

	public float taxRate = 0;
	public float healthcareSpending = 0;
	public float educationSpending = 0;

	public GameObject taxSlider;
	public GameObject taxlevel;
	public GameObject healthSlider;
	public GameObject healthlevel;
	public GameObject educationSlider;
	public GameObject educationlevel;

	public GameObject overallProfit;
	public float profit = 0;
	public float percEmployed;
	public float workingPopulation;
	public float overallIncome;
	public float overallIncomeTax;
	public float overallExpenses;

	public GameObject budgetpanel;



	void Start() {
		taxRate = 10;
		educationSpending = 100;
		healthcareSpending = 100;
	}


	void Update() {
		percEmployed = availableJobs / population;
		workingPopulation = population * percEmployed;
		overallIncome = workingPopulation * averageIncome;
		overallIncomeTax = overallIncome * (taxRate / 100);
		overallExpenses = healthcareSpending + educationSpending;
		profit = overallIncomeTax - overallExpenses;

		overallProfit.GetComponent<Text> ().text = "£" + profit;
	}


	public void ChangeTaxRate() {
		taxRate = taxSlider.GetComponent<Slider>().value;
		taxlevel.GetComponent<Text> ().text = taxRate + "%";
	}


	public void ChangeHealthRate() {
		healthcareSpending = healthSlider.GetComponent<Slider>().value;
		healthlevel.GetComponent<Text> ().text =  "£" + healthcareSpending;
	}

	public void ChangeEducationRate() {
		educationSpending = educationSlider.GetComponent<Slider>().value;
		educationlevel.GetComponent<Text> ().text = "£" + educationSpending;
	}

	public void OpenBudget() {
		budgetpanel.SetActive(true);
	}

	public void CloseBudget() {
		budgetpanel.SetActive(false);
	}
}
