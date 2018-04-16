net = require('net');

var clients = [];

net.createServer(function (socket) {

  socket.name = socket.remoteAddress + ":" + socket.remotePort 

  clients.push(socket);

  socket.write("Welcome " + socket.name + "\n");
  trackerdetails(socket.name + " joined the chat\n", socket);
  
  socket.on('data', function (data) {
    trackerdetails(+ "\n " + data, socket);
	
  });
  
  function broadcast(message, sender) {
		
	

  }

   function trackerdetails(trackingMessage) {
        this.device_Id = trackingMessage.substring(0, 12);
        this.massage_type = trackingMessage.substring(12, 16);
        this.imei = trackingMessage.substring(16, 31);
        this.date = trackingMessage.substring(31, 37);
        this.GPS_flag = trackingMessage.substring(37, 38);
        this.Latitude = trackingMessage.substring(38, 47);
        this.Latitude_hemisphere = trackingMessage.substring(47, 48);
        this.Longitude = trackingMessage.substring(48, 58);
        this.Longitude_hemisphere = trackingMessage.substring(58, 59);
        this.Ground_speed = trackingMessage.substring(59, 64);
        this.Time = trackingMessage.substring(64, 70);
        this.Vehicle_angal = trackingMessage.substring(70, 76);
        this.input_output = trackingMessage.substring(76, 84);
        this.mileage_identify = trackingMessage.substring(84, 85);
        this.mileage = trackingMessage.substring(85, 93);
        console.info("device Id: " + this.device_Id);
        console.info("massage type: " + this.massage_type);
        console.info("imei: " + this.imei);
        console.info("date format: " + this.date);
        console.info("GPS flag: " + this.GPS_flag);
        console.info("Latitude: " + this.Latitude);
        console.info("Latitude hemisphere: " + this.Latitude_hemisphere);
        console.info("Longitude: " + this.Longitude);
        console.info("Longitude hemisphere: " + this.Longitude_hemisphere);
        console.info("Ground speed: " + this.Ground_speed);
        console.info("Time : " + this.Time);
        console.info("Vehicle angal: " + this.Vehicle_angal);
        console.info("input/output: " + this.input_output);
        console.info("mileage identify: " + this.mileage_identify);
        console.info("mileage: " + this.mileage);
		console.info("\n");
    }
  


}).listen(8081);

console.log("Chat server running at port 8081\n");