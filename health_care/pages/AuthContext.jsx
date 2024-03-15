// AuthContext.js
import { createContext, useContext, useState, useEffect } from 'react';
import axios from 'axios';
import { useRouter } from 'next/router';
import cookies from 'js-cookie';

const AuthContext = createContext();

// AuthContext.js
export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [Tkey, setTkey] = useState(null);
  const router = useRouter();

  useEffect(() => {
    console.log('User:', user);
    console.log('Tkey:', Tkey);
    // rest of your code
  }, [user, Tkey]);

  const login = (email,Tkey) => {
    sessionStorage.setItem('Tkey', Tkey); 
    setUser( email );
    console.log('email:', email);
    setTkey(Tkey);
    console.log('Token ' + Tkey);
  };

  const logout = () => {
    
    doSignOut(); // Pass Tkey to the doSignOut function
  };

  async function doSignOut() {
    try {
      const response = await axios.post(
        'https://localhost:44307/api/logout',
        {},
        {
          headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': `${Tkey}`, // Include Tkey in the headers
          },
          withCredentials: true,
        }
      );
      
      sessionStorage.removeItem('Tkey');
      router.push('/Auth/Login');
    } catch (error) {
      console.error('Error during signout: ', error);
    }
  }

  return (
    <AuthContext.Provider value={{ user,login, logout, Tkey }}>
      {children}
    </AuthContext.Provider>
  );
};



export const useAuth = () => {
  const auth = useContext(AuthContext);

  if (!auth) {
    throw new Error("useAuth must be used within an AuthProvider");
  }

  return auth;
};
