var InfiniteScroller = InfiniteScroller || {};

InfiniteScroller.Boot = function(){};

//setting game configuration and loading the assets for the loading screen
InfiniteScroller.Boot.prototype = {
  preload: function() {
    //assets we'll use in the loading screen
      this.load.image('preloadbar', '/content/game/assets/images/preloader-bar.png');
  },
  create: function() {
    //the game will have a sky blue background
    this.game.stage.backgroundColor = "#240CBA";

    //have the game centered horizontally
    this.scale.pageAlignHorizontally = true;
    this.scale.pageAlignVertically = true;

    //physics system
    this.game.physics.startSystem(Phaser.Physics.ARCADE);
  
    this.state.start('Preload');
  }
};