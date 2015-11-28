var InfiniteScroller = InfiniteScroller || {};

InfiniteScroller.game = new Phaser.Game(640, 480, Phaser.CANVAS, document.getElementById("game"));

InfiniteScroller.game.state.add('Boot', InfiniteScroller.Boot);
InfiniteScroller.game.state.add('Preload', InfiniteScroller.Preload);
InfiniteScroller.game.state.add('Game', InfiniteScroller.Game);

InfiniteScroller.game.state.start('Boot');

var speedGauge = createGauge("speed", "Speed", 400);
var playersGauge = createGauge("players", "Players", 15);

function updateGauge(){
	var overflow = 0; //10;
	var value = speedGauge.config.min - overflow + (speedGauge.config.max - speedGauge.config.min + overflow*2) *  Math.random();
	speedGauge.redraw(value);
}

// setInterval(updateGauge, 5000);
playersGauge.redraw(1);