import React from 'react';

const Service = () => {
  return (
    <section className="bg-[#F0F7F6] py-6" id="service">
      <div className="container mx-auto max-w-[1100px]">
        <h2 className="text-4xl font-bold text-center mb-8">Healthcare & Blood Donation Services</h2>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
          {/* Blood Donation Card */}
          <div className="bg-white p-6 rounded-lg shadow-md">
            <i className="fas fa-heartbeat text-4xl text-red-500 mb-4"></i>
            <div className="text-xl font-semibold mb-2">Blood Donation</div>
            <div className="text-gray-700">
              <h5 className="text-lg font-semibold mb-2">Save Lives by Donating Blood</h5>
              <p>
                Be a hero in someone's life by donating blood. Your contribution can make a significant impact and save lives in times of need.
                <br />
                Duration: Quick and easy donation process.
                <br />
                <b>Key Services:</b>
                <br />
                Voluntary Blood Donation, Blood Group Testing, Health Checkups, and Donor Recognition Programs.
              </p>
            </div>
          </div>

          {/* Healthcare Consultation Card */}
          <div className="bg-white p-6 rounded-lg shadow-md">
            <i className="fas fa-hospital text-4xl text-red-500 mb-4"></i>
            <div className="text-xl font-semibold mb-2">Healthcare Consultation</div>
            <p className="text-gray-700">
              🌡️ Access Quality Healthcare! 🏥 <br />
              🩺 Expert Consultations <br /> 💊 Personalized Health Plans <br /> 📋 Medical Advice <br />
              🚑 Emergency Services <br /> 🌐 Telehealth Solutions <br />
              📞 Call Us for Consultation: <br />
              📞 0123456789 <br />
              📧 info@healthconnect.com <br />
              🌐 www.healthconnect.com <br /> <br />
              Prioritize Your Health with HealthConnect! 💙
            </p>
          </div>

          {/* Blood Bank Services Card */}
          <div className="bg-white p-6 rounded-lg shadow-md">
            <i className="fas fa-tint text-4xl text-red-500 mb-4"></i>
            <div className="text-xl font-semibold mb-2">Blood Bank Services</div>
            <p className="text-gray-700">
              🏥 Ensuring Adequate Blood Supply! 💉<br />
              🅰️ Blood Typing and Testing <br />🔄 Blood Transfusion Services <br />🛡️ Blood Storage Facilities <br />
              🌐 Quick Access to Blood Units <br />🤝 Community Blood Drives <br />
              🌐 Contact us for Assistance: <br />
              📞 01761234567 <br />
              📧 bloodbank@healthconnect.com <br />
              🌐 www.healthconnectbloodbank.com <br /> <br />
              Support the Lifesaving Mission with HealthConnect Blood Bank! ❤️
            </p>
          </div>
        </div>
      </div>
    </section>
  );
};

export default Service;
