mergeInto(LibraryManager.library, 
{
	HTMLButtonCreate: function(objectNames) 
	{	  			
		var videoPlayerName = UTF8ToString( objectNames );	
		
		var vidButton = document.createElement('button');
		vidButton.id = 'Test Button';
		vidButton.style.left = '-50%';
		vidButton.style.height = '200%';
		vidButton.style.width = '200%';
		vidButton.style.position = 'absolute';
		vidButton.style.opacity = '.45';
		vidButton.style.top = '-50%';

		vidButton.onclick = function(){		
		window.globalUnityInstance.SendMessage( videoPlayerName, 'InitVideo' );
			vidButton.remove();
		}

	document.body.appendChild(vidButton);	
	}
}
 );
