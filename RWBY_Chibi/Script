var speedLoop=1000/60;
var myCanvasContext,canvasWidth,canvasHeight;
var hauteurSol=55, scrollX=0, decalScroll=350;

///////////////////////////////////////////////////////////////////////////////////////////

var joystick=0,joyTrigger=0,joyOld=0;
var nbVie = 3;
var score = 0;
var gameOver = false;
var forceGet = false;

///////////////////////////////////////////////////////////////////////////////////////////

var timeWhenGameStarted = Date.now();
var stseconds = 0;  
var seconds = 0;
var gameTimer;

///////////////////////////////////////////////////////////////////////////////////////////

var myAudio = document.createElement("audio");
	 myAudio.src = "assets/audio/Red_Like_Roses-By_Jeff_Williams_feat._Casey_Lee_Williams.mp3";

///////////////////////////////////////////////////////////////////////////////////////////

function chrono() {
	seconds++;
	setTimeout(function(){chrono();},100)
};

function ui(){
	var c = document.getElementById("myCanvas");
	var ctx = c.getContext("2d");

	ctx.font = "30px RWBY";
				ctx.fillText(nbVie + " hearts",5,60);
				ctx.fillText(parseInt(seconds/10)+ " Sec " + (seconds%10),5,80);
				ctx.fillText("Score: "+ score,5,100);
}

function start() {

	//------Begin the audio + timer---------//
				chrono();
				myAudio.addEventListener('ended',function(){
					this.currentTime = 0;
					this.play();
				}, false);
				myAudio.play();

	//----------------------------------------//
	//----------------------------------------//
		//--- Uploads all the pictures ---//
	//----------------------------------------//
	//----------------------------------------//

	// environment
	imgDecor = loadImage(new Array("assets/img/parallax_-2.png","assets/img/parallax_-1.png","assets/img/parallax_0.png","assets/img/parallax_1.png","assets/img/parallax_2.png"),endLoad);
	// Animating the player - finish the RWBY sprites
	imgArret = loadImage(new Array("assets/img/arret.png"),endLoad);
	imgBaisse = loadImage(new Array("assets/img/baisse.png"),endLoad);
	img4pattes = loadImage(new Array("assets/img/4pattes0.png","assets/img/4pattes1.png","assets/img/4pattes2.png","assets/img/4pattes3.png"),endLoad);
	imgSautArret = loadImage(new Array("assets/img/sautArret0.png","assets/img/sautArret1.png","assets/img/sautArret2.png","assets/img/sautArret3.png","assets/img/sautArret4.png","assets/img/sautArret5.png"),endLoad);
	imgSaut = loadImage(new Array("assets/img/saut0.png","assets/img/saut1.png","assets/img/saut2.png"),endLoad);
	imgCourse = loadImage(new Array("assets/img/course0.png","assets/img/course1.png","assets/img/course2.png","assets/img/course3.png","assets/img/course4.png","assets/img/course5.png","assets/img/course6.png","assets/img/course7.png"),endLoad);
	imgRoulade = loadImage(new Array("assets/img/roulade0.png","assets/img/roulade1.png","assets/img/roulade2.png","assets/img/roulade3.png","assets/img/roulade4.png"),endLoad);
	// Crow ( bird with bonus ) , Griffon ( points ) and Nevermore ( points ) and rose, FINISH THE SPRITES
	imgBird = loadImage(new Array("assets/img/bird0.png","assets/img/bird1.png","assets/img/bird2.png","assets/img/bird3.png","assets/img/bird4.png","assets/img/bird5.png","assets/img/bird6.png","assets/img/bird7.png","assets/img/bird8.png","assets/img/bird9.png","assets/img/bird10.png","assets/img/bird11.png","assets/img/bird12.png","assets/img/bird13.png"),endLoad);
	imgBird2 = loadImage(new Array("assets/img/bird2-0.png","assets/img/bird2-1.png","assets/img/bird2-3.png","assets/img/bird2-4.png","assets/img/bird2-5.png","assets/img/bird2-6.png","assets/img/bird2-7.png"),endLoad);
	imgBird3 = loadImage(new Array("assets/img/bird3-0.png","assets/img/bird3-1.png","assets/img/bird3-2.png","assets/img/bird3-3.png","assets/img/bird3-4.png","assets/img/bird3-5.png","assets/img/bird3-6.png","assets/img/bird3-7.png","assets/img/bird3-8.png"),endLoad);
	imgRose = loadImage(new Array("assets/img/rose.png"),endLoad);
	imgBirdMort = loadImage(new Array("assets/img/birdChoc.png"),endLoad);
	// Beowolf
	imgBeowolf = loadImage(new Array("assets/img/ours1.png","assets/img/ours2.png","assets/img/ours3.png","assets/img/ours4.png","assets/img/ours5.png","assets/img/ours6.png","assets/img/ours7.png","assets/img/ours8.png","assets/img/ours9.png"),endLoad);
			// Plateforme
	imgPlateforme = loadImage(new Array("assets/img/p1.png","assets/img/p2.png","assets/img/p3.png"),endLoad);

///////////////////////////////////////////////////////////////////////////////////////////

}
///////////////////////////////////////////////////////////////////////////////////////////
function endLoad() {

		//-------------------------//
		//-------------------------//
	    //--- setting the canvas ---//
		//-------------------------//
		//-------------------------//
		var canvas=document.getElementById("myCanvas");
		canvas.width=canvasWidth;
		canvas.height=canvasHeight;		
		myCanvasContext=canvas.getContext("2d");

		canvasWidth=document.getElementById('idBody').clientWidth;
		canvasHeight=document.getElementById('idBody').clientHeight;

	//-------------------------------------------------------//
	//-------------------------------------------------------//
	    //---  Wait for all the graphics to be loaded ---//
	//-------------------------------------------------------//
	//-------------------------------------------------------//
	
	if(	imgDecor.isReady &&
		imgArret.isReady && imgCourse.isReady && imgBaisse.isReady && img4pattes.isReady && imgSautArret.isReady && imgSaut.isReady && imgRoulade.isReady &&
		imgBird.isReady && imgBird2.isReady && imgBird3.isReady && imgRose.isReady && imgBirdMort.isReady &&
		imgBeowolf.isReady &&
		imgPlateforme.isReady) {

		
		Gravite=.5;
		
		perso=new Array();
		perso[0]=new Object();
		perso[0].delai=0;
		perso[0].frequence=6;
		perso[0].etape=0;
		perso[0].x=1000;
		perso[0].vx=0;
		perso[0].y=0;
		perso[0].vy=0;
		perso[0].sens=0;
		perso[0].roulade=false;
		perso[0].baisseArret=false;
		perso[0].yHaut=0;
		perso[0].yBas=0;
		perso[0].xGauche=0;
		perso[0].xDroite=0;
		perso[0].draw=drawPerso;
		
		scrollX=perso[0].x-decalScroll;

		bird=new Array();
		for(var i=0;i<5;i++) {
			bird[i]=new Object();
			bird[i].delai=0;
			bird[i].frequence=6;
			bird[i].drop=false;
			bird[i].etape=0;
			bird[i].x=scrollX+(Math.random()*1024)+canvasWidth+imgBird[0].width;
			bird[i].vx=-((Math.random()*2)+1);
			bird[i].y=(Math.random()*400)+200;
			bird[i].sens=1;
			bird[i].draw=drawBird;
			bird[i].yHaut=0;
			bird[i].yBas=0;
			bird[i].xGauche=0;
			bird[i].xDroite=0;
			bird[i].mort=false;
			bird[i].vy=0;

			//bird[i].type=parseInt(Math.random()*3)
			var r=Math.random()*100;
			if(r<60) bird[i].type=0; else if(r<90) bird[i].type=2; else bird[i].type=1;
		}

		rose=new Array();

		beowolf=new Array();
		beowolf[0]=new Object();
		beowolf[0].delai=0;
		beowolf[0].frequence=6;
		beowolf[0].etape=0;
		beowolf[0].x=0;
		beowolf[0].vx=4;
		beowolf[0].y=0;
		beowolf[0].vy=0;
		beowolf[0].sens=0;
		beowolf[0].yHaut=0;
		beowolf[0].yBas=0;
		beowolf[0].xGauche=0;
		beowolf[0].xDroite=0;
		beowolf[0].saut=false;
		beowolf[0].draw=drawBeowolf;

		plateforme=new Array();
			for(var i=0;i<5;i++) {
		plateforme[i]=new Object();
		plateforme[i].delai=0;
		plateforme[i].frequence=6;
		plateforme[i].etape=0;
		plateforme[i].x=scrollX+(Math.random()*1024)+canvasWidth;
		plateforme[i].y=((Math.random()*4)*200)+200;
		plateforme[i].size=parseInt(Math.random()*4);
		plateforme[i].draw=drawPlateforme;
		plateforme[i].yHaut=0;
		plateforme[i].yBas=0;
		plateforme[i].xGauche=0;
		plateforme[i].xDroite=0;
	}
		
		//-----------------------//
		//-----------------------//
		//--- Prepare the Player ---//
		//-----------------------//
		//-----------------------//
		joystick=4;

		//------------------------------//
		//------------------------------//
		//--- Lance la boucle du jeu ---//
		//------------------------------//
		//------------------------------//
		setTimeout(loop,speedLoop);
	}
}




var frame=0;
var vxParticule=vxParticule2=0;
function loop() {

	//-----------------------------//
	//-----------------------------//
	//--- Gestion du joyTrigger ---//
	//-----------------------------//
	//-----------------------------//
	joyTrigger=(joyOld^joystick)&joystick;
	joyOld=joystick;
	
	//-----------------------------------//
	//-----------------------------------//
	//--- Gestion du compteur d'image ---//
	//-----------------------------------//
	//-----------------------------------//
	frame++;
	
	//---------------------------------------//
	//---------------------------------------//
	//--- Affichage des messages de debug ---//
	//---------------------------------------//
	//---------------------------------------//
	

	//--------------------------------------------------------//
	//--------------------------------------------------------//
	//--- Remplissage du canvas avec la couleur par defaut ---//
	//--------------------------------------------------------//
	//--------------------------------------------------------//
	myCanvasContext.fillStyle="#9d0e13";
	myCanvasContext.fillRect(0,0,canvasWidth,canvasHeight);
	
	//---------------------------//
	//---------------------------//
	//--- On trace les arbres ---//
	//---------------------------//
	//---------------------------//
	var x,w;
	var xf=Math.floor(scrollX*.25);	
	for(x=0;x<canvasWidth;) {
		w=imgDecor[4].width-((xf+x)%imgDecor[4].width);
		if(w>canvasWidth) w=canvasWidth;
		myCanvasContext.drawImage(imgDecor[4],((xf+x)%imgDecor[4].width),imgDecor[4].height-canvasHeight,w,canvasHeight,x,canvasHeight-imgDecor[2].height,w,imgDecor[2].height);
		x+=w;
	}
	xf=Math.floor(scrollX*.5);	
	for(x=0;x<canvasWidth;) {
		w=imgDecor[3].width-((xf+x)%imgDecor[3].width);
		if(w>canvasWidth) w=canvasWidth;
		myCanvasContext.drawImage(imgDecor[3],((xf+x)%imgDecor[3].width),imgDecor[3].height-canvasHeight,w,canvasHeight,x,canvasHeight-imgDecor[2].height,w,imgDecor[2].height);
		x+=w;
	}
	//---------------------------//
	//---------------------------//
	//--- Affichage du player ---//
	//---------------------------//
	//---------------------------//
	//ManagementPlayer();
	for(var i=0;i<perso.length;i++) {
		perso[i].draw();
	}
	//--------------------------//
	//--------------------------//
	//--- Affichage des Beowolves ---//
	//--------------------------//
	//--------------------------//
	for(var i=0;i<beowolf.length;i++) {
		beowolf[i].draw();
	}
	//--------------------------------//
	//--------------------------------//
	//--- Affichage des plateforme ---//
	//--------------------------------//
	//--------------------------------//
	for(var i=0;i<plateforme.length;i++) {
		plateforme[i].draw();
	}
	//-----------------------//
	//-----------------------//
	//--- On trace le sol ---//
	//-----------------------//
	//-----------------------//
	xf=Math.floor(scrollX);	
	for(x=0;x<canvasWidth;) {
		w=imgDecor[2].width-((xf+x)%imgDecor[2].width);
		if(w>canvasWidth) w=canvasWidth;
		myCanvasContext.drawImage(imgDecor[2],((xf+x)%imgDecor[2].width),imgDecor[2].height-canvasHeight,w,canvasHeight,x,canvasHeight-imgDecor[0].height,w,imgDecor[0].height);
		x+=w;
	}
	
	//----------------------//
	//----------------------//
	//--- Les particules ---//
	//----------------------//
	//----------------------//
	myCanvasContext.save();
	
	//--- L'alpha ---//
	var v=128;	// OBLIGATOIREMENT une puissance de 2
	var a=((frame&v)?v-(frame&(v-1)):(frame&(v-1)));
	myCanvasContext.globalAlpha = (a/v); 
	//--- Le Y ---//
	var decY=-frame&((v<<1)-1);
	//--- Le X ---//
	var decX=(Math.random()*2)-1;
	vxParticule+=decX;
	//--- affichage plan 1 ---//
	xf=Math.floor(scrollX*1.01)+vxParticule;
	for(x=0;x<canvasWidth;) {
		w=imgDecor[1].width-((xf+x)%imgDecor[1].width);
		if(w>canvasWidth) w=canvasWidth;
		myCanvasContext.drawImage(imgDecor[1],((xf+x)%imgDecor[1].width),imgDecor[1].height-canvasHeight+decY,w,canvasHeight,x,0,w,canvasHeight);
		x+=w;
	}
	
	//--- L'alpha ---//
	v=59;
	a=(((frame/v)&1)?v-(frame%v):(frame%v));
	myCanvasContext.globalAlpha = (a/v); 
	//--- Le Y ---//
	decY=-frame%(v<<1);
	//--- Le X ---//
	decX=(Math.random()*2)-1;
	vxParticule2+=decX;
	//--- affichage plan 2 ---//
	xf=Math.floor(scrollX*.8)+vxParticule2+200;
	for(x=0;x<canvasWidth;) {
		w=imgDecor[1].width-((xf+x)%imgDecor[1].width);
		if(w>canvasWidth) w=canvasWidth;
		myCanvasContext.drawImage(imgDecor[1],((xf+x)%imgDecor[1].width),imgDecor[1].height-canvasHeight+decY,w,canvasHeight,x,0,w,canvasHeight);
		x+=w;
	}
	myCanvasContext.restore();
	
	//---------------------------//
	//---------------------------//
	//--- Affichage des birds---//
	//---------------------------//
	//---------------------------//
	for(var i=0;i<bird.length;i++) {
		bird[i].draw();
	}

	//---------------------------//
	//---------------------------//
	//--- Affichage des roses---//
	//---------------------------//
	//---------------------------//
	for(var i=0;i<rose.length;i++) {
		rose[i].draw();
	}

	//-------------------------------------//
	//-------------------------------------//
	//--- Gestion du placement du décor ---//
	//-------------------------------------//
	//-------------------------------------//
	if(perso[0].sens==0) {
		if(scrollX<perso[0].x-decalScroll) scrollX+=((perso[0].x-decalScroll)-scrollX)/16;
	} else {
		if(scrollX+canvasWidth-decalScroll>perso[0].x) scrollX-=((scrollX+canvasWidth-decalScroll)-perso[0].x)/16;
	}
	// Sécurité...
	if(scrollX<0) scrollX=0;

	//---------------------------//
	//---------------------------//
	//--- test les collisions ---//
	//---------------------------//
	//---------------------------//
	if(b=testCollisionPersoBird()) {
		b.mort=true;
		b.vy=0;
	}
	testCollisionPersoBeowolf();

	testCollisionPersoRose();

	//testCollisionPersoPlateform();


	//-----------UI-----------//
	ui();


	function gameEnd(){
	if(nbVie<=0){
		gameOver=true;
		return;
	}
	return;
	}

	gameEnd();

	//-------------------------//
	//-------------------------//
	//--- Relance la boucle ---//
	//-------------------------//
	//-------------------------//
	if(!gameOver) {
		setTimeout(loop,speedLoop);
	} else {
							window.clearInterval(gameTimer);
							var timeSurvived = (Date.now() - timeWhenGameStarted)/1000;
							myAudio.pause();
							alert("Game Over ! You survived for " + timeSurvived + " sec." + " with a score of " + score);
							location.reload(forceGet);
	}
}
///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////

//function ManagementPlayer() {
var drawPerso=function() {

	
	var vXMax=7;
	if(this.roulade==false) {
		if(this.y==0 || this.auSol) {
			
			if(joyTrigger&2) {
				this.vy=15;
			}
			if(joystick&5) {
				if(joystick&1) {
					if(this.vx>-vXMax) this.vx--; else this.vx++;
					this.sens=1;
				}
				if(joystick&4) {
					if(this.vx<vXMax) this.vx++; else this.vx--;
					this.sens=0;
				}
			} else {
				if(this.vx>0) this.vx--;
				else if(this.vx<0) this.vx++;
			}
		}
	}
	this.x+=this.vx;
	
	this.y+=this.vy;
	this.vy-=Gravite;
	if(this.y<0) this.y=0;
	
	var anim;              
	if(this.roulade) {
		anim=imgRoulade;
	} else {
		if(this.y!=0 && !this.auSol) {
			if(this.vx==0) {
				anim=imgSautArret;
			} else {
				anim=imgSaut;
			}
		} else {
			if(this.vx==0) {
				anim=imgArret;
				if(joystick&8) {
					this.baisseArret=true;
					anim=imgBaisse;
				} else {
					this.baisseArret=false;
				}
			} else {
				anim=imgCourse;
				if(joystick&8) {
					if(this.baisseArret==false) {
						this.roulade=true;
						this.etape=0;
						if(this.vx<0) this.vx=-vXMax; else this.vx=vXMax;
					}
					anim=img4pattes;
				} else {
					this.baisseArret=false;
				}
			}
		}
	}
	if(this.etape>=anim.length) {
		this.etape=0;
	}

	if(this.y!=0 && !this.auSol) {
		if(this.vx==0) {
			if(this.vy>10) {
				this.etape=0;
			} else if(this.vy>0) {
				this.etape=1;
			} else if(this.vy>-10) {
				this.etape=2;
			} else {
				this.etape=3;
			}
		} else {
			if(this.vy>3) {
				this.etape=0;
			} else if(this.vy>-3) {
				this.etape=1;
			} else {
				this.etape=2;
			}
		}
	} else {
		this.delai++;
		if(this.delai>=this.frequence) {
			this.delai=0;
			this.etape++;
			if(this.etape>=anim.length) {
				this.etape=0;
				if((joystick&8)==0) this.roulade=false;
			}
		}
	}
	var img=anim[this.etape];
	
	this.yHaut=canvasHeight-hauteurSol-img.height-this.y;
	this.yBas=this.yHaut+img.height;
	this.xGauche=this.x-(img.width/2);
	this.xDroite=this.x+(img.width/2);
	
	//--- Les paramètres sont : (image, x, y) ---//
	myCanvasContext.save();
	if(this.sens) {
		myCanvasContext.scale(-1,1);
		myCanvasContext.translate(-(this.x-scrollX)*2,0);
	}
	myCanvasContext.drawImage(img,this.x-scrollX-(img.width/2),canvasHeight-hauteurSol-(img.height)-this.y);		// le personnage
	myCanvasContext.restore();	
}
///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////

var drawBird=function() {

	var anim=imgBird;
	if(this.type==1) {
			if(this.x-perso[0].x <=300 && this.drop==false){
				var redrose=new Object();
				for (var i=0; i<1; i++){
				redrose.delai=0;
				redrose.frequence=6;
				redrose.etape=0;
				redrose.x=this.x;
				redrose.y=this.y;
				redrose.vx=0;
				redrose.vy=0;
				redrose.draw=drawRose;
				redrose.yHaut=0;
				redrose.yBas=0;
				redrose.xGauche=0;
				redrose.xDroite=0;
				redrose.draw = drawRose;
				rose.push(redrose);
					}
					this.drop=true;
			}
		this.mort=false;
		anim=imgBird2;

	} else if(this.type==2) {
		this.mort=false;
		anim=imgBird3;
	}
	if(this.mort) {
		this.etape=0;
		anim=imgBirdMort;
		this.y+=this.vy;
		this.vy-=Gravite;
	}
	this.x+=this.vx;
	
	if(this.x-scrollX<-imgBird[0].width) {
		this.mort=false;
		this.drop=false;
		this.etape=0; 												//permet d'avoir des animations différentes avec un nb d'img différent
		this.y=(Math.random()*400)+200;
		this.vx=-((Math.random()*2)+1);
		this.x=canvasWidth+imgBird[0].width+scrollX;

			//bird[i].type=parseInt(Math.random()*3)
			var r=Math.random()*100;
			if(r<60) this.type=0; else if(r<90) this.type=2; else this.type=1;
	}
	
	this.delai++;
	if(this.delai>=this.frequence) {
		this.delai=0;
		this.etape++;
		if(this.etape>=anim.length) {
			this.etape=0;
		}
	}
	var img=anim[this.etape];
	
	this.yHaut=canvasHeight-hauteurSol-(img.height/2)-this.y;
	this.yBas=canvasHeight-hauteurSol-(img.height/2)-this.y+img.height;
	this.xGauche=this.x-(img.width/2);
	this.xDroite=this.x+(img.width/2);
	
	//--- Les paramètres sont : (image, x, y) ---//
	myCanvasContext.save();
	if(this.sens) {
		myCanvasContext.scale(-1,1);
		myCanvasContext.translate(-(this.x-scrollX)*2,0);
	}
	myCanvasContext.drawImage(img,this.x-scrollX-(img.width/2),canvasHeight-hauteurSol-(img.height/2)-this.y);		// le personnage
	myCanvasContext.restore();	
}

var drawRose= function() {

	var anim=imgRose;

	this.y+=this.vy;
	this.vy-=Gravite;
	this.vx=0;
	this.x+=this.vx;
	this.etape=0;
	if(this.y<0) this.y=0;

	var img=anim[this.etape];
	
	this.yHaut=canvasHeight-hauteurSol-(img.height/2)-this.y;
	this.yBas=canvasHeight-hauteurSol-(img.height/2)-this.y+img.height;
	this.xGauche=this.x-(img.width/2);
	this.xDroite=this.x+(img.width/2);

	//--- Les paramètres sont : (image, x, y) ---//
	myCanvasContext.save();
	if(this.sens) {
		myCanvasContext.scale(-1,1);
		myCanvasContext.translate(-(this.x-scrollX)*2,0);
	}
	myCanvasContext.drawImage(img,this.x-scrollX-(img.width/2),canvasHeight-hauteurSol-(img.height/2)-this.y);		// pour que la rose tombe sur le sol
	myCanvasContext.restore();
}

///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////

function testCollisionPersoBird() {

	for(var i=0;i<bird.length;i++) {
		if(	!bird[i].mort &&
			perso[0].xDroite>bird[i].xGauche &&
			perso[0].xGauche<bird[i].xDroite &&
			perso[0].yHaut<bird[i].yBas &&
			perso[0].yBas>bird[i].yHaut &&
			score ++)
			return bird[i];
	}
	return null;
}

function testCollisionPersoBeowolf() {

	for(var i=0;i<beowolf.length;i++) {
		if(	perso[0].xDroite>beowolf[i].xGauche &&
			perso[0].xGauche<beowolf[i].xDroite &&
			perso[0].yHaut<beowolf[i].yBas &&
			perso[0].yBas>beowolf[i].yHaut) {
				nbVie--;
				return;
			}
	}
	return;
}

function testCollisionPersoRose(){
	for(var i=0;i<rose.length;i++) {
		if(	perso[0].xDroite>rose[i].xGauche &&
			perso[0].xGauche<rose[i].xDroite &&
			perso[0].yHaut<rose[i].yBas &&
			perso[0].yBas>rose[i].yHaut) {
			nbVie ++;
			return;
			}
	}
	return;
}

/*function testCollisionPersoPlateform(){
	for(var i=0;i<plateforme.length;i++) {
		if(perso[0].yBas>plateforme[i].yHaut || this.auSol) {
			y'a quelque chose ici que j'ai pas trouvé
			return;
			}
	}
	return;
}*/



///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////

var drawBeowolf=function() {

	var anim=imgBeowolf;
	
	this.delai++;
	if(this.delai>=this.frequence) {
		this.delai=0;
		this.etape++;
		if(this.etape>=anim.length) {
			this.etape=0;
		}
	}
	// si saut, on bloque l'anim
	if(this.saut && this.y!=0) {
		this.etape=4;
	}
/*	if(this.saut && this.y==0) {
		this.saut=false;
		this.vx=4;
	}*/
	var img=anim[this.etape];
	
	// on ne distance pas plus le beowolf
	this.x+=this.vx;
	if(this.x<perso[0].x-decalScroll-((img.width*2)/3)) {
		this.x=perso[0].x-decalScroll-((img.width*2)/3);
	}
	// le beowolf bondit sur le joueur
	if(!this.saut && perso[0].x-this.x<(decalScroll*2/3)) {
		this.saut=true;
		this.vx=3;
		this.vy=10;
	}

	//le beowolf fait demi-tour si le joueur est derrière lui
	if(this.x>perso[0].x){
		this.vx=-3;
		this.sens=1;
		}
	
	if(this.x<perso[0].x){
		this.vx=3;
		this.sens=0;
		}

	
	this.y+=this.vy;
	this.vy-=Gravite;
	if(this.y<0) this.y=0;
	
	this.yHaut=canvasHeight-hauteurSol-(img.height)-this.y;
	this.yBas=canvasHeight-hauteurSol-(img.height)-this.y+img.height;
	this.xGauche=this.x-(img.width/2);
	this.xDroite=this.x+(img.width/2);
	
	//--- Les paramètres sont : (image, x, y) ---//
	myCanvasContext.save();
	if(this.sens) {
		myCanvasContext.scale(-1,1);
		myCanvasContext.translate(-(this.x-scrollX)*2,0);
	}
	myCanvasContext.drawImage(img,this.x-scrollX-(img.width/2),canvasHeight-hauteurSol-(img.height)-this.y);		// beowolf posé sur le sol
	myCanvasContext.restore();	
}

///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////

var drawPlateforme=function() {

	this.yHaut=canvasHeight-hauteurSol-(imgPlateforme[0].height)-this.y;
	this.yBas =this.yHaut+imgPlateforme[0].height;
	this.xGauche=this.x;
	this.xDroite=this.x+(imgPlateforme[0].width+(imgPlateforme[1].width*this.size)+imgPlateforme[2].width);

	if(this.x-scrollX<-imgPlateforme[0].width) {	
		this.y=(Math.random()*400)+200;
		this.vx=-((Math.random()*2)+1);
		this.x=canvasWidth+imgPlateforme[0].width+scrollX;

	}


	
	//--- Les paramètres sont : (image, x, y) ---//
	myCanvasContext.save();
	var x=this.x;
	myCanvasContext.drawImage(imgPlateforme[0],x-scrollX,canvasHeight-hauteurSol-this.y);
	x+=imgPlateforme[0].width;
	for(var i=0;i<this.size;i++) {
		myCanvasContext.drawImage(imgPlateforme[1],x-scrollX,canvasHeight-hauteurSol-this.y);
		x+=imgPlateforme[1].width;		
	}
	myCanvasContext.drawImage(imgPlateforme[2],x-scrollX,canvasHeight-hauteurSol-this.y);
	myCanvasContext.restore();	
}
