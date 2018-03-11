using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	public enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor, stairs, lightplace, stageup, stagedown, floor, 
		legs, hospital, closed_door, window, bars, guard, lose, hide, wait, stelth, kill, narnia, strangle, freedom, open_door, defeat};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print(myState);
		if (myState == States.cell)				 {cell();} 
		else if (myState == States.mirror) 	 {mirror();} 
		else if (myState == States.sheets_0) 	 {sheets_0();} 
		else if (myState == States.sheets_1)	 {sheets_1();} 
		else if (myState == States.lock_0) 		 {lock0();}
		else if (myState == States.lock_1) 		 {lock1();}
		else if (myState == States.cell_mirror)  {cell_mirror();}
		else if (myState == States.corridor)  {coridor();}
		// second stage
		else if (myState == States.stairs) {stairs();}
		else if (myState == States.stageup) {stageup();}
		else if (myState == States.stagedown) {stagedown();}
		else if (myState == States.floor) {floor();}
		else if (myState == States.legs) {legs();}
		else if (myState == States.hospital) {hospital();}
		else if (myState == States.closed_door) {closed_door();}
		else if (myState == States.window) {window();}
		else if (myState == States.bars) {bars();}
		else if (myState == States.lightplace) {lightplace();}
		else if (myState == States.guard) {guard();}
		else if (myState == States.lose) {lose();}
		else if (myState == States.hide) {hide();}
		else if (myState == States.wait) {wait();}
		else if (myState == States.stelth) {stelth();}
		else if (myState == States.kill) {kill();}
		else if (myState == States.narnia) {narnia();}
		else if (myState == States.strangle) {strangle();}
		else if (myState == States.freedom) {freedom();}
		else if (myState == States.open_door) {open_door();}

	}
	
	#region second_chapter
	
	void freedom() {
		text.text = "Вы на свободе. Поздравляю! \n\n" + 
		"Нажми P чтобы начать сначала....";
		if (Input.GetKeyDown(KeyCode.P)) {myState = States.cell;}
	}
	
	void open_door() {
		text.text = "Вы у двери во двор. Можно идти. \n\n" +
		"Нажми на F чтобы выйти на свободу";
		
		if (Input.GetKeyDown(KeyCode.F)) { myState = States.freedom; }		
	}
	
	void narnia() {
		text.text = "Вы в Нарнии. Тут Хорошо! ВсЕгО ХоРоШеГо! \n\n" +
		"Нажми R чтобы вернуться";
	    if (Input.GetKeyDown(KeyCode.R)) { myState = States.hide; }		
	}
	
	void bars() {
		text.text = "На окнах решетка. Вы не сможете её сломать. \n\n" +
		"Нажми R чтобы вернуться " ;
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.stagedown;}
	}
	
	void stelth() {
	text.text = "Вы обходите охранника, он вас не замечает. Останавливаетесь у двери на выход. Он встаёт в туалет пописать, вы в этот момент можете оказаться на свободе!"
	+ "\n\n" + "Нажми D чтобы открыть дверь, R чтобы вернуться";
		if (Input.GetKeyDown(KeyCode.D)) { myState = States.open_door; }
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.wait; }		
	}
	
	void strangle() {
		text.text = "Вы голыми руками набрасываетесь на охранника и убиваете его!" + "\n\n" +
			"Нажми D чтобы подойти к входной двери";
		if (Input.GetKeyDown(KeyCode.D)) { myState = States.open_door; }		
	}		
	
	void kill() {
		text.text = "Вы резко набрасываетесь на охранника. У вас преимущество!" + "\n\n" +
			"Нажми S чтобы задушить охранника, и D чтобы стоять и ничего не делать";
		if (Input.GetKeyDown(KeyCode.D)) { myState = States.lose; }
		else if (Input.GetKeyDown(KeyCode.S)) { myState = States.strangle; }
	}
	
	void defeat() {
		text.text = "Вы проиграли. Охранник одолел вас. Вы снова в клетке. + \n\n"
		+ "Нажми P чтобы начать сначала.";
		
		if (Input.GetKeyDown(KeyCode.P)) { myState = States.cell; }	
	}
	
	void lose() {
		text.text = "Он пытается схватить вас ограмеными руками." + "\n\n" +
			"Нажми K чтобы атаковать охранника, D чтобы сдаться.";
		if (Input.GetKeyDown(KeyCode.K)) { myState = States.kill; }
		else if (Input.GetKeyDown(KeyCode.D)) {myState = States.defeat; }
	}
	
	void wait() {
		text.text = "Вы ждёте. Ничего примечательного не происходит. \n\n" +
		"Нажми N чтобы пролесь в коридор, K чтобы наброситься на охранника, S чтобы прокрасться через охрану, R чтобы вернуться";
		if (Input.GetKeyDown(KeyCode.N)) { myState = States.narnia; }
		else if (Input.GetKeyDown(KeyCode.K)) {myState = States.kill; }
		else if (Input.GetKeyDown(KeyCode.S)) {myState = States.stelth; }
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.hide; }
	}
			
	void hide() {
		text.text = "Вы тихонько притаились и ждёте что-то... Немного в темноте вы видите узкий коридор." + "\n\n" +
			"Нажми W чтобы ждать, N что бы проползти в коридор, R чтобы вернуться.";
		if (Input.GetKeyDown(KeyCode.W)) { myState = States.wait; }
		else if (Input.GetKeyDown(KeyCode.N)) {myState = States.narnia; }
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.lightplace; }
	}
		
	void guard () {
		text.text = "Охранник выглядит большим. Возможно у вас не получиться его одолеть. Что будете делать?" + "\n\n" +
			"Нажми K чтобы наброситься, X чтобы чихнуть, R чтобы вернуться.";
		if (Input.GetKeyDown(KeyCode.K)) { myState = States.kill; }
		else if (Input.GetKeyDown(KeyCode.X)) {myState = States.lose; }
		else if (Input.GetKeyDown (KeyCode.R)) {myState = States.lightplace; }
	}
		
	void lightplace() {
		text.text = "Пойдя на свет и шум вы замечаете охранника. Он пялится в телевизор и жрёт попкорн. Рано или поздно он куда нибудь уйдёт." + "\n\n" +
			"Нажми H чтобы спрятаться, G чтобы подойти ближе к охраннику, R чтобы вернуться.";
		if (Input.GetKeyDown(KeyCode.H)) { myState = States.hide; }
		else if (Input.GetKeyDown(KeyCode.G)) {myState = States.guard; }
		else if (Input.GetKeyDown (KeyCode.R)) {myState = States.corridor; }
	}
		
	void window() {
		text.text = "На окнах вы видите решетку. Разбивать стекло смысла нет. Среди прутьев не пробраться." + "\n\n" +
			"Нажми R чтобы вернуться";
		if (Input.GetKeyDown(KeyCode.R)) { myState = States.stagedown; }		
	}
	
	void closed_door() {
		text.text = "Вы дёргаете ручку двери, а она никак не открывается. Похоже закрыто." + "\n\n" +
			"Нажми R чтобы вернуться";
		if (Input.GetKeyDown(KeyCode.R)) { myState = States.stagedown; }		
	}
		
	void hospital() {
		text.text = "Вы тихонечко доковыляли до больницы и пришли к доктору." + "\n\n" +
			"Нажми F чтобы попасть на свободу, P чтобы начать игру сначала";
		if (Input.GetKeyDown(KeyCode.P)) { myState = States.cell; }	
		else if (Input.GetKeyDown(KeyCode.F)) {myState = States.freedom; }	
	}
	
	void legs() {
		text.text = "Вы спрыгнули с крыши на асфальт и неудачно преземлились. Прохрамав пару шагов вы садитесь на пол. Понимаете что нога скорее всего сломана и нужно в больницу." + "\n\n" +
			"Нажми H чтобы пойти в больницу, P чтобы начать игру сначала..";
		if (Input.GetKeyDown(KeyCode.H)) { myState = States.hospital; }
		else if (Input.GetKeyDown(KeyCode.P)) {myState = States.cell; }
	}
	
	void floor() {
		text.text = "Вы на крыше. Похоже что тут не высоко. Теплый воздух свободы обдувает вам лицо. Солнце печет глаза. Побыстрее бы домой." + "\n\n" +
			"Нажми L чтобы спрыгнуть, R чтобы вернуться.";
		if (Input.GetKeyDown(KeyCode.L)) { myState = States.legs; }
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.stageup; }
	}
	
	void stagedown() {
		text.text = "Вы спускаетесь вниз и видите окно и дверь" + "\n\n" +
			"Нажми W чтобы подойти к окну, D чтобы открыть дверь, R чтобы вернуться";
		if (Input.GetKeyDown(KeyCode.W)) { myState = States.bars; }
		else if (Input.GetKeyDown(KeyCode.D)) { myState = States.closed_door; }
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.stairs; }
	}
		
	void stageup() {
	text.text = "Вы поднялись выше и видите дверь на крышу. \n\n"
		+ "Нажми F чтобы выйти на крышу, R чтобы вернуться";
		
		if (Input.GetKeyDown(KeyCode.F)) { myState = States.floor; }
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.stairs; }
	}
	
	void stairs() {
	text.text = "Вы на лестнице. Тут тихо и полумрак. Можно подняться на этаж выше или вниз. \n\n"
			+ "Нажми U чтобы подняться вверх и D чтобы спуститься, R чтобы вернуться в коридор";
	
	if (Input.GetKeyDown(KeyCode.U)) { myState = States.stageup; }
	else if (Input.GetKeyDown(KeyCode.D)) {myState = States.stagedown; }
	else if (Input.GetKeyDown(KeyCode.R)) {myState = States.corridor; }
	}
	
	#endregion chapter
	
	#region first_chapter
	void cell () {
		text.text = "Вы очутились в заперти. Тут как в тюрме. Нары и зеркало на стене и клетка закрытая на замок. Нужно выбраться отсюда. Что будете делать?\n\n"
					+ "Нажми S чтобы посмотреть на нары, M изучить зеркало и L чтобы изучить замок";
		
		if (Input.GetKeyDown(KeyCode.S)) { myState = States.sheets_0; }
		else if (Input.GetKeyDown(KeyCode.M)) { myState = States.mirror; }
		else if (Input.GetKeyDown(KeyCode.L)) { myState = States.lock_0; }
	}	
		
	void sheets_0 () {
		text.text = "Ничего примечательно просто нары." 
					+ "\n\n"
					+ "Нажми R чтобы вернуться";			 
		
		if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
	}
	
	void mirror() {
		text.text = "Вы видите небольшое зеркало. Оно может пригодиться." 
					+ "\n\n" +
					"Нажми T чтобы взять зеркало, или R чтобы вернуться";
		
		if (Input.GetKeyDown(KeyCode.T)) { myState = States.cell_mirror; }
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell; }
	}
	
	void cell_mirror() {
		text.text = "Вы взяли зеркало. Что будете делать дальше?" 
					+ "\n\n" +
					"Нажмите S чтобы спать на нарах, L изучить замок или R чтобы повесить зеркало на место";
	 	
	 	if (Input.GetKeyDown(KeyCode.L)) { myState = States.lock_1; }
	 	else if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell; }
		else if (Input.GetKeyDown(KeyCode.S)) {myState = States.sheets_1; }
	}
	
	void lock0() {
		text.text = "Замок с кнопками. Вроде можно разглядеть какие то отпечатки.." 
				+"\n\n"
				+ "Нажми R чтобы вернуться в клетку";			 
		if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
	}
		
	void sheets_1 () {
		text.text = "Улечся с зеркалом на нарах это не лучший способ для побега." 
					+"\n\n"
					+ "Нажми R чтобы вернуться в клетку";			 
		if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell_mirror; }
	}

	void lock1() {
		text.text = "Вы аккуратно вытаскиваете зеркало из клетки и поварачиваете, чтобы увидеть замок. Вы можете просто по отпечаткам понять какой код." 
					+"\n\n"
					+ "Нажми O чтобы открыть замок, или R чтобы вернуться";			 
		if (Input.GetKeyDown(KeyCode.O)) { myState = States.corridor; }
		else if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell_mirror; }
	}
	
	void coridor() {
		text.text = "Вы нажали на кнопки и код подошел! Замок щелкнул и вы открыли дверь! Вы в коридоре. Первый этап побега пройден!" 
					+ "\n\n"
					+ "Нажми S чтобы идти на лестницу, L чтобы идти на свет, R чтобы вернуться";		
		if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor; }
		else if (Input.GetKeyDown(KeyCode.S)) { myState = States.stairs; }
		else if (Input.GetKeyDown(KeyCode.L)) { myState = States.lightplace; }
	}
	
	#endregion
}