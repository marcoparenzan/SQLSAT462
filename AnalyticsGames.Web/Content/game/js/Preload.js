var InfiniteScroller = InfiniteScroller || {};

//loading the game assets
InfiniteScroller.Preload = function(){};

InfiniteScroller.Preload.prototype = {
  preload: function() {
    //show loading screen
    this.preloadBar = this.add.sprite(this.game.world.centerX, this.game.world.centerY, 'preloadbar');
    this.preloadBar.anchor.setTo(0.5);
    this.preloadBar.scale.setTo(3);

    this.load.setPreloadSprite(this.preloadBar);

    //load game assets
    this.load.spritesheet('dog', '/content/game/assets/images/running1.png', 104, 104, 8);
    this.load.image('ground', '/content/game/assets/images/ground.png');
    this.load.image('grass', '/content/game/assets/images/city-silhouette.png');
  },
  create: function() {
    this.state.start('Game');
  }
};