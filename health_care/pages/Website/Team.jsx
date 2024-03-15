// Team.jsx
import React from 'react';

const Team = () => {
  const teamMembers = [
    {
      name: 'MD FAHAD KHAN',
      role: 'User',
      bio: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
      imageUrl: '/fahad.jpg', // Replace with the actual image URL
    },
    {
      name: 'MD. GOLAM RABBANI RAFI',
      role: 'Admin',
      bio: 'Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.',
      imageUrl: '/rafi.jpeg', // Replace with the actual image URL
    },
    {
      name: 'MD RAKIBUL ISLAM',
      role: 'Service Provider',
      bio: 'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.',
      imageUrl: '/Rijom.jpg', // Replace with the actual image URL
    },
    // Add more team members as needed
  ];

  return (
    <div className="bg-gradient-to-r from-[#F0F7F6] to-[#e1e8e7] min-h-screen flex flex-col justify-center items-center">
      <div className="w-full  p-24 bg-gradient-to-r from-[#F0F7F6] to-[#e1e8e7] rounded-md  ">
        <h1 className="text-4xl text-center font-extrabold mb-8 text-gray-700">Meet Our Team</h1>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
          {teamMembers.map((member, index) => (
            <div key={index} className="bg-white p-6 rounded-lg shadow-md text-center">
              <img
                src={member.imageUrl}
                alt={member.name}
                className="w-32 h-32 mx-auto mb-4 rounded-full object-cover"
              />
              <h2 className="text-xl font-semibold mb-2 text-gray-800">{member.name}</h2>
              <p className="text-gray-600 mb-2">{member.role}</p>
              <p className="text-gray-700">{member.bio}</p>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Team;
