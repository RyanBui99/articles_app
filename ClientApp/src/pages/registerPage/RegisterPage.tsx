import React, { useState } from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import ILoginRegister from '../../interfaces/ILoginRegister';
import NavbarComponent from '../../components/NavbarComponent';
import { APIService } from '../../helpers/APIService';
import { AlertColor } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import SnackbarComponent from '../../components/SnackbarComponent';

export default function RegisterPage() {
  const navigate = useNavigate();
  const [open, setOpen] = useState(false);
  const [message, setMessage] = useState('');
  const [severity, setSeverity] = useState<AlertColor>();

  const handleClick = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    const registerData: ILoginRegister = {
      username: data.get('username')!.toString(),
      password: data.get('password')!.toString(),
    };
    try {
      await APIService.register(registerData);
      setSeverity('success');
      navigate('/login');
    } catch (error: any) {
      setSeverity('error');
      setMessage(error.response.data.message);
    }
  };

  return (
    <>
      <NavbarComponent />
      <Container
        component='main'
        maxWidth='xs'
        className='login_page'
        sx={{
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
          height: '90vh',
        }}
      >
        <SnackbarComponent
          open={open}
          handleClose={handleClose}
          message={message}
          severity={severity}
        />
        <Box
          sx={{
            display: 'flex',
            justifyContent: 'center',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Typography component='h1' variant='h5'>
            Register
          </Typography>
          <Box
            component='form'
            onSubmit={handleSubmit}
            noValidate
            sx={{ mt: 1 }}
          >
            <TextField
              margin='normal'
              required
              fullWidth
              id='username'
              label='username'
              name='username'
              autoComplete='username'
              autoFocus
            />
            <TextField
              margin='normal'
              required
              fullWidth
              name='password'
              label='Password'
              type='password'
              id='password'
              autoComplete='current-password'
            />
            <Button
              type='submit'
              fullWidth
              variant='contained'
              sx={{ mt: 3, mb: 2 }}
              onClick={handleClick}
            >
              Sign up
            </Button>
          </Box>
        </Box>
      </Container>
    </>
  );
}
