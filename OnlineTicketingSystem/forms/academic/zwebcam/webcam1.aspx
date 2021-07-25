<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webcam1.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.zwebcam.webcam1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	<title>Capture Image</title>
    <style type="text/css">
		body { font-family: Helvetica, sans-serif; }
		h1, h2, h3 { margin-top:0; margin-bottom:0; }
		form { margin-top: 15px; }
		form input { margin-right: 15px; }
		#results { display:inline-block; margin:20px; padding:20px; border:1px solid; background:#ccc; }
	</style>
</head>
<body>
<form id="form1" runat="server">
    <div>
    <%--<h1>WebcamJS Test Page</h1>
	<h3>Demonstrates all features at once</h3>--%>
	<%--<div style="margin-top:5px; margin-bottom:20px;">Captures large 480x480 cropped image while displaying live 240x240 preview, flipped horizontally (mirrored), and allows preview before save.</div>--%>
	
	<div id="my_photo_booth" style="text-align: center">
		<div id="my_camera" style="margin: 0 auto"></div>
		
		<!-- First, include the Webcam.js JavaScript Library -->
		<script type="text/javascript" src="/webcamjs-master/webcam.min.js"></script>
		
        <script src="/Scripts/jquery-ui-1.9.2.custom/development-bundle/jquery-1.8.3.js" type="text/javascript"></script>
		<!-- Configure a few settings and attach camera -->
		<script language="JavaScript">
		    Webcam.set({
		        // live preview size
		        width: 500,
		        height: 500,

		        // device capture size
		        dest_width: 500,
		        dest_height: 500,

		        // final cropped size
		        //crop_width: 300,
		        //crop_height: 300,

		        // format and quality
		        image_format: 'jpeg',
		        jpeg_quality: 90,

		        // flip horizontal (mirror mode)
		        flip_horiz: true
		    });
		    Webcam.attach('#my_camera');
		</script>
		
		<!-- A button for taking snaps -->
		<form >
			<div id="pre_take_buttons" style="margin-top: 10px;margin-left: 10px">
				<!-- This button is shown before the user takes a snapshot -->
				<input type=button value="Take Snapshot" onClick="preview_snapshot()">
			</div>
			<div id="post_take_buttons" style="display: none;margin-top: 10px">
				<!-- These buttons are shown after a snapshot is taken -->
				<input type=button value="&lt; Take Another" onClick="cancel_preview()">
				<input type=button value="Save Photo &gt;" onClick="save_photo()" style="font-weight:bold;">
			</div>
		</form>
	</div>
	
	<div id="results" style="display:none">
		<!-- Your captured image will appear here... -->
	</div>
	
	<!-- Code to handle taking the snapshot and displaying it locally -->
	<script language="JavaScript">
	    // preload shutter audio clip
	    var shutter = new Audio();
	    shutter.autoplay = false;
	    shutter.src = navigator.userAgent.match(/Firefox/) ? 'shutter.ogg' : 'shutter.mp3';

	    function preview_snapshot() {
	        // play sound effect
	        try { shutter.currentTime = 0; } catch (e) {; } // fails in IE
	        shutter.play();

	        // freeze camera so user can preview current frame
	        Webcam.freeze();

	        // swap button sets
	        document.getElementById('pre_take_buttons').style.display = 'none';
	        document.getElementById('post_take_buttons').style.display = '';
	    }

	    function cancel_preview() {
	        // cancel preview freeze and return to live camera view
	        Webcam.unfreeze();

	        // swap buttons back to first set
	        document.getElementById('pre_take_buttons').style.display = '';
	        document.getElementById('post_take_buttons').style.display = 'none';
	    }

	    function save_photo() {
	        // actually snap photo (from preview freeze) and display it
	        Webcam.snap(function (data_uri) {
	            // display results in page
	            //	            document.getElementById('results').innerHTML =
	            //					'<h2>Here is your large, cropped image:</h2>' +
	            //					'<img src="' + data_uri + '"/><br/></br>' +
	            //					'<a href="' + data_uri + '" target="_blank">Open image in new window...</a>';

	            $.ajax({
	                url: "webcam1.aspx/fnSaveImage1",

	                type: "POST",

	                data: "{'dataurl' :'" + data_uri + "'}",

	                //dataType: "json",
	                contentType: "application/json; charset=utf-8",

	                async: false,
	                success: function (res) {

	                    r = res.d;
	                    var s = r.split("|");
	                    if (s[0] != "success") {
	                        alert(r);
	                    } else {
	                        //alert(s[1]);
	                        //Webcam.reset();
	                       update(s[1]);
	                        //self.close();
	                    }
	                    //alert(r);
	                    //alert("Success");
	                    //return r;
	                },
	                error: function (err) {
	                    alert("ERROR : " + err);
	                }


	            });


	            // shut down camera, stop capturing
	            //Webcam.reset();
	            //self.close();
	            // show results, hide photo booth
	            //document.getElementById('results').style.display = '';
	            //document.getElementById('my_photo_booth').style.display = 'none';
	            //alert(data_uri);
	        });
	    }

	    function update(updstr) {
	        //alert("Hi");
	        //alert(updstr);
	        var ctlid = $("#<%= ctlid_v.ClientID%>").val();
	        var ctlid2 = $("#<%= ctlid2_v.ClientID%>").val();
	        //alert(ctlid);
	        window.opener.update3(updstr, ctlid, ctlid2);
	        Webcam.reset();
	        self.close();
	    }

	    //	    $(document).ready(function () {
	    //	        $("[id$='Image1']").attr("src", "/edusoft_logo1.jpg");
	    //	    });
    </script>
     <asp:Image ID="Image1" runat="server" />
    </div>
    <asp:HiddenField ID="ctlid_v" runat="server" />
    <asp:HiddenField ID="ctlid2_v" runat="server" />
    </form>
     
</body>
</html>
