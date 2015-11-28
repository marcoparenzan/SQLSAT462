var InfiniteScroller = InfiniteScroller || {};

InfiniteScroller.Game = function () { };

InfiniteScroller.Game.prototype = {
    preload: function () {
        this.game.time.advancedTiming = true;
    },
    create: function () {

        //set up background and ground layer
        this.game.world.setBounds(0, 0, 3500, this.game.height);
        this.grass = this.add.tileSprite(0, this.game.height - 470, this.game.world.width, 400, 'grass');
        this.ground = this.add.tileSprite(0, this.game.height - 70, this.game.world.width, 70, 'ground');

        //create player and walk animation
        this.player = this.game.add.sprite(this.game.width / 2, this.game.height - 90, 'dog');
        this.player.animations.add('walk');

        //put everything in the correct order (the grass will be camoflauge),
        //but the toy mounds have to be above that to be seen, but behind the
        //ground so they barely stick up
        this.game.world.bringToTop(this.ground);

        //enable physics on the player and ground
        this.game.physics.arcade.enable(this.player);
        this.game.physics.arcade.enable(this.ground);

        //player gravity
        this.player.body.gravity.y = 1000;

        //so player can walk on ground
        this.ground.body.immovable = true;
        this.ground.body.allowGravity = false;

        //properties when the player is digging, scratching and standing, so we can use in update()
        this.player.standDimensions = { width: this.player.width, height: this.player.height };
        this.player.anchor.setTo(0.5, 1);

        //the camera will follow the player in the world
        this.game.camera.follow(this.player);

        //move player with cursor keys
        this.cursors = this.game.input.keyboard.createCursorKeys();

        //set some variables we need throughout the game
        this.wraps = 0;
        this.points = 0;
        this.wrapping = true;
        this.stopped = false;

        //stats
        var style1 = { font: "20px Arial", fill: "#ff0" };
        var t1 = this.game.add.text(10, 20, "Speed:", style1);
        t1.fixedToCamera = true;

        var style2 = { font: "26px Arial", fill: "#00ff00" };
        this.speedText = this.game.add.text(80, 18, "", style2);
        this.speedText.fixedToCamera = true;

        // customization
        this.velocityX = 0;
        this.playerAnimation = this.player.animations.play('walk', 3, true);
    },

    update: function () {
        //collision
        this.game.physics.arcade.collide(this.player, this.ground, this.playerHit, null, this);

        //only respond to keys and keep the speed if the player is alive
        //we also don't want to do anything if the player is stopped for scratching or digging
        if (this.player.alive && !this.stopped) {

            this.player.body.velocity.x = this.velocityX;
            if (this.velocityX > 0) {
                this.playerAnimation.delay = 10000 / this.velocityX;
            }
            this.speedText.text = this.velocityX || 0;

            //We do a little math to determine whether the game world has wrapped around.
            //If so, we want to destroy everything and regenerate, so the game will remain random
            if (!this.wrapping && this.player.x < this.game.width) {
                //Not used yet, but may be useful to know how many times we've wrapped
                this.wraps++;

                //We only want to destroy and regenerate once per wrap, so we test with wrapping var
                this.wrapping = true;

                //put everything back in the proper order
                this.game.world.bringToTop(this.ground);
            }
            else if (this.player.x >= this.game.width) {
                this.wrapping = false;
            }

            if (this.game.externalUpdate != undefined) {
                this.game.externalUpdate(this);
            }

            if (this.cursors.left.isDown) {
                if (this.velocityX > 10) {
                    this.velocityX -= 10;
                }
            }
            if (this.cursors.right.isDown) {
                if (this.velocityX < 400) {
                    this.velocityX += 10;
                }
            }

            //The game world is infinite in the x-direction, so we wrap around.
            //We subtract padding so the player will remain in the middle of the screen when
            //wrapping, rather than going to the end of the screen first.
            this.game.world.wrap(this.player, -(this.game.width / 2), false, true, false);
            this.grass.x = this.game.camera.x * 0.7;
        }

    }
};