import { Paper, Box, Typography } from '@mui/material';
import React from 'react';
import { useDispatch } from 'react-redux';
import { Container, Button } from 'reactstrap';
import AdminUserTable from '../../components/AdminUserTable';
import CreateUserModal from '../../components/modals/CreateUserModal';
import NavbarComponent from '../../components/NavbarComponent';
import { useTypedSelector } from '../../hooks/useTypeSelector';
import { getUsers } from '../../store/actionCreators/userCreator';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    flexGrow: 1,
  },
  container: {
    marginTop: theme.spacing(4),
  },
  paper: {
    padding: theme.spacing(3),
    color: theme.palette.text.secondary,
  },
}));

export default function admin() {
  const [open, setOpen] = React.useState(false);
  const dispatch = useDispatch();
  const { users } = useTypedSelector((state) => state.users);
  const classes = useStyles();

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  React.useEffect(() => {
    dispatch(getUsers());
  }, [dispatch]);

  return (
    <>
      <NavbarComponent />
      <div className={classes.root}>
        <Container className={classes.container} maxWidth='md'>
          <Paper className={classes.paper}>
            <Box display='flex'>
              <Box flexGrow={2}>
                <Typography
                  component='h2'
                  variant='h6'
                  color='primary'
                  gutterBottom
                >
                  USERS
                </Typography>
              </Box>
              <Box>
                <Button
                  variant='contained'
                  color='primary'
                  onClick={handleClickOpen}
                >
                  CREATE
                </Button>
                <CreateUserModal handleclose={handleClose} open={open} />
              </Box>
            </Box>
            <AdminUserTable users={users} />
          </Paper>
        </Container>
      </div>
    </>
  );
}
