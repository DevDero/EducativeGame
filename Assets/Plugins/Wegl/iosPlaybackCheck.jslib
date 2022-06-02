mergeInto(LibraryManager.library, 
{
	$ContentVideo: {},
	OpenUrl: function(url)
	{
		window.open(UTF8ToString(url), "_blank");

	}

	HTMLVideoSolution: function(objectNames) 
  	{	  		
		//alert("Tap the screen to play the video");
	
		var videoPlayerName = UTF8ToString( objectNames );	

		
		var vidButton = document.createElement('button');
		vidButton.id = 'Test Button';
		vidButton.style.left = '-50%';
		vidButton.style.height = '200%';
		vidButton.style.width = '200%';
		//vidButton.style.zIndex = '1010';
		vidButton.style.position = 'absolute';
		vidButton.style.opacity = '.45';
		vidButton.style.top = '-50%';

		//Add Button Listener
		vidButton.onclick = function(){		
		window.unityInstance.SendMessage( videoPlayerName, 'Play' );
			vidButton.remove();
		}

	document.body.appendChild(vidButton);	
  }
}
 );